
static void ManageTrainerData(string[] trainerID, string[] trainerName, string[] mailingAddress, string[] trainerEmail){
    StreamReader infile = new StreamReader("trainers.txt");
    string line = infile.ReadLine(); //priming read
    string[] copy = new string[6000];
    int count = 0;
    while( line != null){
        copy[count] = line;
        string[] temp = line.Split("#");
        trainerID[count] = temp[0];
        trainerName[count] = temp[1];
        mailingAddress[count] = temp[2];
        trainerEmail[count] = temp[3];
        count += 1;
        line = infile.ReadLine(); //update read
    }
    System.Console.WriteLine("Which would you like to do:");
    System.Console.WriteLine("1- Add");
    System.Console.WriteLine("2- Edit");
    System.Console.WriteLine("3- Delete");
    System.Console.WriteLine("4- Return to Menu");
    int menuChoice = int.Parse(Console.ReadLine());
    infile.Close();
    if(menuChoice == 1){
        count = AddTrainerData(trainerID, trainerName, mailingAddress, trainerEmail, count);
    }
    else if(menuChoice == 2){
        count = EditTrainerData(trainerID, trainerName, mailingAddress, trainerEmail, copy, count);
    }
    else if(menuChoice == 3){
        count = DeleteTrainerData(trainerID, trainerName, mailingAddress, trainerEmail, copy, count);
    }
    else if(menuChoice == 4){
    }
}
static int AddTrainerData(string[] trainerID, string[] trainerName, string[] mailingAddress, string[] trainerEmail, int count){
    StreamWriter infile = new StreamWriter("trainers.txt", true);
    System.Console.WriteLine("Please enter Trainer ID:");
    int ID = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Please enter trainer name:");
    string name = Console.ReadLine();
    System.Console.WriteLine("Please enter trainer address:");
    string address = Console.ReadLine();
    System.Console.WriteLine("Please enter trainer email");
    string email = Console.ReadLine();
    infile.WriteLine();
    infile.Write(ID);
    infile.Write("#");
    infile.Write(name);
    infile.Write("#");
    infile.Write(address);
    infile.Write("#");
    infile.Write(email);
    infile.Close();
    return count;
}
static int EditTrainerData(string[] trainerID, string[] trainerName, string[] mailingAddress, string[] trainerEmail, string[] copy, int count){
     StreamWriter infile = new StreamWriter("trainers.txt");
    System.Console.WriteLine("Which of these trainers would you like to EDIT:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to edit {trainerName[i]}, userID:{trainerID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    infile = new StreamWriter("trainers.txt", true);
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            infile.WriteLine(copy[i]);
        }
    }
    string name = trainerName[choice-1];
    string ID = trainerID[choice - 1];
    string mailingAddressString = mailingAddress[choice - 1];
    string email = trainerEmail[choice - 1];
    //------------------------------- Reworking the edited line
    while(1 == 1){
        System.Console.WriteLine("What would you like to edit:");
        System.Console.WriteLine($"1- Trainer ID, current:{ID}");
        System.Console.WriteLine($"2- Trainer Name, current:{name}");
        System.Console.WriteLine($"3- Mailing Address, current:{mailingAddressString}");
        System.Console.WriteLine($"4- Trainers Email, current:{email}");
        System.Console.WriteLine("5- Return to Menu");
        choice = 0;
        choice = int.Parse(Console.ReadLine());
        if(choice == 1){
            System.Console.WriteLine("Please enter new Trainer ID:");
            ID = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 2){
            System.Console.WriteLine("Please enter new name:");
            name = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 3){
            System.Console.WriteLine("Please enter new mailing address:");
            mailingAddressString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 4){
            System.Console.WriteLine("Please enter new email:");
            email = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 5){
            break;
        }
    }
    //Paste back edited line
    infile.Write(ID);
    infile.Write("#");
    infile.Write(name);
    infile.Write("#");
    infile.Write(mailingAddressString);
    infile.Write("#");
    infile.Write(email);
    infile.Close();
    return count;
}
static int DeleteTrainerData(string[] trainerID, string[] trainerName, string[] mailingAddress, string[] trainerEmail, string[] copy, int count){
    StreamWriter infile = new StreamWriter("trainers.txt");
    System.Console.WriteLine("Which of these trainers would you like to DELETE:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to delete {trainerName[i]}, userID:{trainerID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    int hasTyped = 0;
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            if(hasTyped == 0){
                infile = new StreamWriter("trainers.txt");
                infile.WriteLine(copy[i]);
                infile.Close();
                hasTyped = 1;
            }
            else if((i == count-1) || ((i == count-2) && (choice==count-1))){
                infile = new StreamWriter("trainers.txt", true);
                infile.Write(copy[i]);
                infile.Close();
            }
            else if(hasTyped == 1){
                infile = new StreamWriter("trainers.txt", true);
                infile.WriteLine(copy[i]);
                infile.Close();
            }

        }

    }
    infile.Close(); 

    return count-1;
}
static void ManageListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken){
    StreamReader infile = new StreamReader("listings.txt");
    string line = infile.ReadLine(); //priming read
    string[] copy = new string[6000];
    int count = 0;
    while( line != null){
        copy[count] = line;
        string[] temp = line.Split("#");
        listingID[count] = temp[0];
        listingName[count] = temp[1];
        listingDate[count] = temp[2];
        listingTime[count] = temp[3];
        listingCost[count] = temp[4];
        listingTaken[count] = temp[5];
        count += 1;
        line = infile.ReadLine(); //update read
    }
    System.Console.WriteLine("Which would you like to do:");
    System.Console.WriteLine("1- Add");
    System.Console.WriteLine("2- Edit");
    System.Console.WriteLine("3- Delete");
    System.Console.WriteLine("4- Return to Menu");
    int menuChoice = int.Parse(Console.ReadLine());
    infile.Close();
    if(menuChoice == 1){
        count = AddListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken, count);
    }
    else if(menuChoice == 2){
        count = EditListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken, count);
    }
    else if(menuChoice == 3){
        count = DeleteListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken, count);
    }
    else if(menuChoice == 4){

    } 
}
static int AddListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken, int count){
StreamWriter infile = new StreamWriter("listings.txt", true);
    System.Console.WriteLine("Please enter listing ID:");
    int ID = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Please enter trainer name:");
    string name = Console.ReadLine();
    System.Console.WriteLine("Please enter the date of the session:");
    string date = Console.ReadLine();
    System.Console.WriteLine("Please enter the time of the session");
    string time = Console.ReadLine();
    System.Console.WriteLine("Please enter the cost of the session:");
    string cost = Console.ReadLine();
    System.Console.WriteLine("Please enter if the listing is available:");
    string taken = Console.ReadLine();
    infile.WriteLine();
    infile.Write(ID);
    infile.Write("#");
    infile.Write(name);
    infile.Write("#");
    infile.Write(date);
    infile.Write("#");
    infile.Write(time);
    infile.Write("#");
    infile.Write(cost);
    infile.Write("#");
    infile.Write(taken);
    infile.Close();
    return count;
}
static int EditListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken, int count){

return count;
}
static int DeleteListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken, int count){

return count;
}
static void ManageCustomerBookings(){

}
static void RunReports(){

}

//-----------------------------------------------------------------
//Main

//Menu
while(1 == 1){
string[] trainerID = new string[6000];
string[] trainerName = new string[6000];
string[] mailingAddress = new string[6000];
string[] trainerEmail = new string[6000];
string[] listingID = new string[6000];
string[] listingName = new string[6000];
string[] listingDate = new string[6000];
string[] listingTime = new string[6000];
string[] listingCost = new string[6000];
string[] listingTaken = new string[6000];
System.Console.WriteLine("Which would you like to do:");
System.Console.WriteLine("1- Manage Trainer Data");
System.Console.WriteLine("2- Manage Listing Data");
System.Console.WriteLine("3- Manage Customer Booking Data");
System.Console.WriteLine("4- Run Reports");
System.Console.WriteLine("5- Exit");
int menuChoice = int.Parse(Console.ReadLine());
//Menu Selections
if(menuChoice == 1){
    ManageTrainerData(trainerID, trainerName, mailingAddress, trainerEmail);
}
else if(menuChoice == 2){
    ManageListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken);
}
else if(menuChoice == 3){
    ManageCustomerBookings();
}
else if(menuChoice == 4){
    RunReports();
}
else if(menuChoice == 5){
    break;
}




}
