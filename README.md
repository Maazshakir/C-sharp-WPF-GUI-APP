# C-sharp-WPF-GUI-APP
Backend:

1) There are two custom data types defined :
	- Worksheet(MunkaLapok.cs)
	- Work(Work.cs)
2) Work.cs includes the conversion of time and the calculation of labour fee (munkadij)
3) Loader.cs consists of a single generic function for file loading
4) Parser.cs also has a single function which parse the read line to Work data type
5) Log.cs has 2 static lists:
	- filename : which stores the name of file(it can be used for future enhancement)
	- munkaLapok : which stores the worksheet data after submition (For fizetes menu)

GUI:

1) GUI is designed using WPF
2) There are 4 Menus:
	- Info : which includes documentation
	- Munkalap : which displays the worksheet after reading file
	- Fizetes : which displays the total submitted worksheet data
	- Névjegy : which displays my neptun code , name & current date
3) File can loaded by "Fajlbetöltes" button , it will performs following steps:
	- You can only load .txt or .csv files
	- After loading software will validate file, if there is any problem it will notify you with error message
	- It will also enable Payment (Fizetes) & Worksheet (Munkalap) menu
4) Exit "Kilépés" button will confirm if you would like to exit before closing the application
