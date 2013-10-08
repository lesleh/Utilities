#!/bin/bash

INSTALL_DIR=$HOME/bin
MONO_SHIM=run_mono_exe

echo Building all projects...
xbuild /p:Configuration=Release Utilities.sln > /dev/null

find . -type d ! -iname ".*" -maxdepth 1 | while read line; do
	PROJECT=$(basename $line)
	echo Installing $PROJECT

	rm -f $INSTALL_DIR/$PROJECT
	cp "$PROJECT/bin/Release/$PROJECT.exe" "$INSTALL_DIR/$PROJECT.exe"
	chmod -x "$INSTALL_DIR/$PROJECT.exe" # The .exe isn't directly executable
	ln -s $MONO_SHIM $INSTALL_DIR/$PROJECT
done