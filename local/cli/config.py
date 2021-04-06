import os
class classproperty(object):
    def __init__(self, getter):
        self.getter= getter
    def __get__(self, instance, owner):
        return self.getter(owner)

class Config(object):
    @classproperty
    def root_directory(self):
        return os.getenv('loan_local_root_directory', '/home/esi/iWorks/loan/')

    @classproperty
    def working_directory(self):
        return os.path.join(self.root_directory, 'local')

    @classproperty
    def root_domain(self):
        return 'loan-local.com'

    @classproperty
    def domain(self):
        return 'www.{}'.format(self.root_domain)
