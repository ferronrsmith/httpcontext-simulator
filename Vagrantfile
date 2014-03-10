# -*- mode: ruby -*-
# vi: set ft=ruby :

# Vagrantfile API/syntax version. Don't touch unless you know what you're doing!
VAGRANTFILE_API_VERSION = "2"

Vagrant.configure(VAGRANTFILE_API_VERSION) do |config|
  config.vm.box = "precise64"

  config.vm.box_url = "http://files.vagrantup.com/precise64.box"

  config.vm.provider :virtualbox do |vb|
    vb.customize ["modifyvm", :id, "--memory", "512"]
  end

  config.vm.provision :shell, :path => "vagrant/provisioning/install-rvm.sh",  :args => "stable"
  config.vm.provision :shell, :path => "vagrant/provisioning/install-ruby.sh", :args => "2.1.0 puppet"

  config.vm.provision :puppet do |puppet|
     puppet.manifests_path = "vagrant/manifests"
     puppet.manifest_file  = "mono.pp"
  end

  config.vm.provision :shell, :path => "vagrant/provisioning/dev-setup.sh"
end
