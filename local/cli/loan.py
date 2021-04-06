import os
import subprocess
from builtins import open
from config import Config
from component import Component
import re
import click
from python_hosts import Hosts, HostsEntry
import yaml

__author__ = "Esmaeel Zekaee"

@click.group()
def main():
    """
    The `Loan` local environment cli 
    """
    pass

@main.command()
def build():
    """Builds the components"""
    config = Config()
    subprocess.run(['docker-compose', 'build'], cwd=config.working_directory)
    
@main.command()
def register():
    """Registers the hosts names and in the host file (run with root privilege)"""
    config = Config()
    print ('adding hosts')
    hosts = []

    hostsFile = Hosts()
    entries = HostsEntry(entry_type='ipv4', address='127.0.0.1', names=hosts)
    hostsFile.add([entries])
    hostsFile.write()
    components = all_components()
    for component in components:
        print ('checking hosts for {}'.format(component.name))
        if (not component.hosts or len(component.hosts) == 0):
            continue

        hosts = component.hosts
        entries = HostsEntry(entry_type='ipv4', address='127.0.0.1', names=hosts)
        hostsFile.add([entries])
        hostsFile.write()

@main.command()
def up():
    """Starts the local environment"""
    config = Config()
    subprocess.run(['docker-compose', 'up', '-d'], cwd=config.working_directory)

@main.command()
def down():
    """Stops the local environment"""
    config = Config()
    subprocess.run(['docker-compose', 'down'], cwd=config.working_directory)

@main.command()
@click.argument('component')
@click.argument('port')
def switch(component, port):
    """Switches docker container to host"""
    host_key = '{}_HOST'.format(component)
    port_key = '{}_PORT'.format(component)
    host_value = 'host.docker.internal'
    if os.name == "posix":
        host_value = "172.17.0.1"
    config = Config()
    print ('Switching to the host...')
    set_env_variable(host_key, host_value)
    set_env_variable(port_key, port)
    subprocess.run(['docker-compose', 'scale', 'nginx=0'], cwd=config.working_directory)
    env = {**os.environ, host_key: host_value, port_key: port}
    subprocess.run(['docker-compose', 'scale', 'nginx=1'], cwd=config.working_directory, env=env)

@main.command()
@click.argument('component')
def reset(component):
    """Switches to the docker container"""
    config = Config()
    host_key = '{}_HOST'.format(component)
    port_key = '{}_PORT'.format(component)
    print ('Switching to the docker container...')
    set_env_variable(host_key, None)
    set_env_variable(port_key, None)
    env = {**os.environ, host_key: '', port_key: ''}
    subprocess.run(['docker-compose', 'scale', 'nginx=0'], cwd=config.working_directory)
    subprocess.run(['docker-compose', 'scale', 'nginx=1'], cwd=config.working_directory, env=env)

def set_env_variable(key, value):
    config = Config()
    dot_env = '{0}/.env'.format(config.working_directory)
    lines = []
    if os.path.isfile(dot_env):
        file = open(dot_env, 'r')
        lines = file.readlines()
        file.close()
    file = open(dot_env, 'w')
    key_found = False
    for line in lines:
        if re.search('^{}='.format(key), line):
            key_found = True
            if value != None:
                file.write('{}={}\n'.format(key, value))
        else:
            file.write(line)
    if key_found == False and value != None:
        file.write('{}={}\n'.format(key, value))
    file.close()

def all_components():
    config = Config()
    manifestFile = os.path.join(config.working_directory, 'manifest.yml')
    if (not os.path.exists(manifestFile)):
        raise Exception('Unable to find the manifest file at: {}'.format(manifestFile))
    manifest = yaml.safe_load(open(manifestFile).read())
    components = []
    for entry in manifest:
        component = Component.load(entry)
        components.append(component)
    return components

if __name__ == "__main__":
    main()

