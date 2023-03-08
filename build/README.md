To generate a package, Open a Developper command prompt for VS 2022 and start the .bat in this folder.

It will ask for the js/css files location. Give it the path to the folder containing the relevant files (see note 1 below).
The next times, it will use the same location (see note 2 below).

It will then ask for the version name of the OpenSilverforBlazor package.

Done.




Note 1: The files are opensilver.js, ResizeObserver.js, velocity.js, etc. as of the day of writing this. They are the files that are needed in wwwroot/libs of the final project.
IMPORTANT NOTE: These files will automatically be added to the project that will reference the package and need to be up to date with the version of OpenSilver which is used for this package. You can typically find them in one of these two locations:
- OpenSilver\src\Runtime\Scripts - if you are using a local build of OpenSilver
- %userprofile%\.nuget\packages\opensilver\SOMEVERSION\js_css (if the packages' locations is the default one) if you are using the SOMEVERSION version of OpenSilver.

Note 2: The location will be saved in a file called "ScriptsLocation.txt". If you want to change it, you can do so directly in the file, or simply delete the file and it will ask again.



