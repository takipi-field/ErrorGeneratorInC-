# Error Generator In C#
A series of code utilities that generate random Java errors. The idea is to build different classes and then use class for name to randomly call them

## Using Error Generator
The main method is in com.overops.ErrorGenerator. It takes in two parameters (length of run in minutes and error types). Example for 5 minutes for all exception types:
```
C:\> ErrorGenerator 5 All
```
The best way to use this is to build an EXE file and then execute it from the command line (right click on the project in Solution Explorer and choose build).

Create a batch file with the following environment variables (make sure to use \\ as seen below in diretory structure)
```
set COR_ENABLE_PROFILING=1
set COR_PROFILER={9E9BF2AC-891E-4AAD-9192-44645082EB3E}
set TAKIPI_ARGS=takipi.symbols.path=<full path to pbd files>\\ErrorGeneratorInC\\bin\Debug\\,takipi.sources.path=<full path to source files>\\ErrorGeneratorInC\\src\\main\\java\\com\\overops\\
```

Alternatively, you can set each TAKIPI environment variable separately instead of TAKIPI_ARGS:
```
set TAKIPI_COLLECTOR_HOST=localhost
set TAKIPI_COLLECTOR_PORT=6060
set TAKIPI_SYMBOLS_PATH=C:\My\Code\Project
set TAKIPI_SOURCE_PATH=/opt/sources/MyApp
```

Once you have the batch file, put it in the bin\debug folder along with the newly create exe file and the pdb file. Open a cmd prompt and navigate to the folder with the executable, pbd and newly created batch file. Execute the batch file to set the environment variables and then execute the executable.

## How to add new Error Utilities
In com.overops.errors, there is BaseError interface. Create a new Error class and implement the BaseError interface (see one of the other classes as an example). This class will be added to the list of classes in the main method class listed above (there is a error map in ErrorGenerator). You can classify your error type in order to generate only null pointers or invalid arguments or run all error types. Once you have the new class created, then create the actual code to create the errors in the com.overops.util package. If you look at an existing class, you will see the pattern. 
