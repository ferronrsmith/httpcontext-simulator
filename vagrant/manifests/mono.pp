

exec { "apt-get update":
    command => "/usr/bin/apt-get update",
}
 
package { "mono-devel":
    ensure => installed,
    require => Exec["apt-get update"],
}

package { "nunit-console":
    ensure => installed,
    require => Package["mono-devel"],
}
