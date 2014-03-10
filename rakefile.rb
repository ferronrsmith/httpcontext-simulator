require 'albacore'

namespace :mono do
  desc "build httpsimulator on mono"
  xbuild :build do |msb|
    msb.properties :configuration => :Debug
    msb.targets :rebuild
    msb.verbosity = 'quiet'
    msb.solution = File.join('.', "HttpSimulator.sln")
  end
end
