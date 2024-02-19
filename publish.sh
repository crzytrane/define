#!/bin/bash

dotnet publish -c 'release' -r 'linux-x64'
ln -s ./bin/release/net8.0/linux-x64/publish/define /usr/bin/define
ln -s ./bin/release/net8.0/linux-x64/publish/define /usr/lib/define
ln -s ./bin/release/net8.0/linux-x64/publish/define /usr/share/define
