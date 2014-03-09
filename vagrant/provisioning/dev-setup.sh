#!/usr/bin/env bash

source /usr/local/rvm/scripts/rvm
# make sure that the ruby gems needed by the project are installed
cd /vagrant/
rvm use 2.1.0
bundle install
# so that you start in the vagrant folder
echo cd \/vagrant > /home/vagrant/.bashrc