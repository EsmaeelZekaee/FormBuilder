class Component(object):
    def __init__(self, name, repository_url, hosts):
        self.name = name
        self.repository_url = repository_url
        self.hosts = hosts

    def yaml(self):
        return yaml.dump(self.__dict__)

    @staticmethod
    def load(data):
        hosts = data['hosts'] if 'hosts' in data else []
        return Component(data['name'], data['repositoryUrl'], hosts)
