require 'albacore'

namespace :mono do
  desc "build httpsimulator on mono"
  xbuild :build do |msb|
    msb.properties :configuration => :Debug
    msb.targets :rebuild
    msb.verbosity = 'quiet'
    msb.solution = File.join('.', "HttpSimulator.sln")
  end

  desc "test with nunit"
  nunit :test => :build do |n|
    n.command = "nunit-console"
    tlib = "HttpSimulator.Tests"
    n.assemblies "#{tlib}/bin/Debug/#{tlib}.dll"
  end
end
