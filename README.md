# Project1-CS3502
This project was split into 2 parts. The first part was then split into four phase
#Phase 1
Develop a program to handle at least 10 threads
#Phase 2
Implement mutex locks and show proper acuisition and release of the locks
#Phase 3
Implement deadlock detection and show a scenario of a deadlock occurring
#Phase 4
Implemetn deadlock prevention and show the recover process

#IPC
Develop a program that uses Pipes (|) to transfer data.

#Solution
For phases 1 through 4 a bank exmaple was used. Phase 1 and 2 only used one class, the BankAccount class to handle the withdrawal and deposit of funds. For phase 3 and 4, another class was created to handle the bank accounts, this is the Bank class. In phase 3, only deadlock detection was implemented using the monitor class in C#. In phase 4, prevention was added using the ordering of locks and using a wait method in the form of TimeSpan.FromSeconds method. For the IPC implementation, two programs must be run at the same time. The IPC-server-part and the IPC-client-part. As it uses named pipes, both must running at the same time in order for any data to be transfered. 

#Downloading the VM and .NET framework
The solution was created and ran in a Linux operating system. To set up the Linux OS, I downloaded the Oracle Virtual Box from theit website. Linux Mint 22 was downlaoded from the Linux website. It is best to follow their instructions when it comes to verifying the Linux download. 
When setting up the Virtual Box, select the Ubuntu distribution. Select any options you think will make the VM run as smoothly as possible without using too much memory. 
I used VS Code and the .NET framework for C#. 
To install the latest .NET framework go to https://learn.microsoft.com/en-us/dotnet/core/install/linux. 
It is best to use the scripted install thus, use these commands tp install .NET
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x ./dotnet-install.sh
./dotnet-install.sh --version latest
To install a specific version use this command. 
./dotnet-install.sh --channel 9.0
The dependencies depend on teh Ubuntu version you are running. If you downlaoded the latest Linux Mint Version than the dependcies are for Ubuntu version 24. The dependencies can be found on this website https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#dependencies
to install the dependecies run this command in terminal
sudo apt install name_of_dependency

#running the solution
Once you have installed the .NET framework and the VS Code IDE in the VM, you can run phase 1 throuogh 4 through the IDE. However when you want to run the IPC transfer, you must use two terminals. One to run the server part, and the other to run the client part. Once you are in their respective directories run this command
dotnet run name_of_file



