
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
        System.Console.WriteLine($"Enter {i+1} to edit {trainerName[i]}, userID: {trainerID[i]}");
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
        System.Console.WriteLine($"1- Trainer ID, current: {ID}");
        System.Console.WriteLine($"2- Trainer Name, current: {name}");
        System.Console.WriteLine($"3- Mailing Address, current: {mailingAddressString}");
        System.Console.WriteLine($"4- Trainers Email, current: {email}");
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
        System.Console.WriteLine($"Enter {i+1} to delete {trainerName[i]}, userID: {trainerID[i]}");
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
            else if(((i == count - 2) && (choice==count)) || (i == count - 1)){
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
        count = EditListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken, count, copy);
    }
    else if(menuChoice == 3){
        count = DeleteListingData(listingID, listingName, listingDate, listingTime, listingCost, listingTaken, count, copy);
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
static int EditListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken, int count, string[] copy){
    StreamWriter infile = new StreamWriter("listings.txt");
    System.Console.WriteLine("Which of these listings would you like to EDIT:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to edit {listingName[i]}, listing ID: {listingID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    infile = new StreamWriter("listings.txt", true);
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            infile.WriteLine(copy[i]);
        }
    }
    string name = listingName[choice-1];
    string ID = listingID[choice - 1];
    string date = listingDate[choice - 1];
    string time = listingTime[choice - 1];
    string cost = listingCost[choice -1];
    string taken = listingTaken[choice -1];

    //------------------------------- Reworking the edited line
    while(1 == 1){
        while(1 == 1){
            System.Console.WriteLine("What would you like to edit:");
            System.Console.WriteLine($"1- Listing ID, current: {ID}");
            System.Console.WriteLine($"2- Listing Name, current: {name}");
            System.Console.WriteLine($"3- Listing Date, current: {date}");
            System.Console.WriteLine($"4- Listing Time, current: {time}");
            System.Console.WriteLine($"5- Listing Cost, current: {cost}");
            System.Console.WriteLine($"6- Available or Taken, current: {taken}");
            System.Console.WriteLine("7- Return to Menu");
            choice = 0;
            choice = int.Parse(Console.ReadLine());
            if((choice == 1) || (choice == 2) || (choice == 3) || (choice == 4) || (choice == 5) || (choice == 6) || (choice == 7)){
                break;
            }
            else{
                System.Console.WriteLine("Error. Invalid Response.");
            }
        }
        if(choice == 1){
            System.Console.WriteLine("Please enter new listing ID:");
            ID = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 2){
            System.Console.WriteLine("Please enter new listing name:");
            name = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 3){
            System.Console.WriteLine("Please enter new listing date:");
            date = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 4){
            System.Console.WriteLine("Please enter new listing time:");
            time = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 5){
            System.Console.WriteLine("Please enter new listing cost:");
            cost = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 6){
            System.Console.WriteLine("Please enter listing availability:");
            taken = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 7){
            break;
        }
    }
    //Paste back edited line
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
static int DeleteListingData(string[] listingID,string[] listingName,string[] listingDate,string[] listingTime,string[] listingCost,string[] listingTaken, int count, string[] copy){
    StreamWriter infile = new StreamWriter("listings.txt");
    System.Console.WriteLine("Which of these listings would you like to DELETE:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to delete {listingName[i]}, listing ID: {listingID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    int hasTyped = 0;
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            if(hasTyped == 0){
                infile = new StreamWriter("listings.txt");
                infile.WriteLine(copy[i]);
                infile.Close();
                hasTyped = 1;
            }
            else if(((i == count - 2) && (choice==count)) || (i == count - 1)){
                infile = new StreamWriter("listings.txt", true);
                infile.Write(copy[i]);
                infile.Close();
            }
            else if(hasTyped == 1){
                infile = new StreamWriter("listings.txt", true);
                infile.WriteLine(copy[i]);
                infile.Close();
            }

        }

    }
    infile.Close(); 

    return count-1;

}
static void ManageCustomerBookings(string[] sessionID,string[] customerName, string[] customerEmail, string[] trainingDate, string[] trainerID, string[] trainerName, string[] status){
    StreamReader infile = new StreamReader("transactions.txt");
    string line = infile.ReadLine(); //priming read
    string[] copy = new string[6000];
    int count = 0;
    while( line != null){
        copy[count] = line;
        string[] temp = line.Split("#");
        sessionID[count] = temp[0];
        customerName[count] = temp[1];
        customerEmail[count] = temp[2];
        trainingDate[count] = temp[3];
        trainerID[count] = temp[4];
        trainerName[count] = temp[5];
        status[count] = temp[6];
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
        count = AddBookingData(sessionID, customerName, customerEmail, trainingDate, trainerID, trainerName, status, count);
    }
    else if(menuChoice == 2){
        count = EditBookingData(sessionID, customerName, customerEmail, trainingDate, trainerID, trainerName, status, count, copy);
    }
    else if(menuChoice == 3){
        count = DeleteBookingData(sessionID, customerName, customerEmail, trainingDate, trainerID, trainerName, status, count, copy);
    }
    else if(menuChoice == 4){

    } 
}
static int AddBookingData(string[] sessionID,string[] customerName, string[] customerEmail, string[] trainingDate, string[] trainerID, string[] trainerName, string[] status, int count){
    StreamWriter infile = new StreamWriter("transactions.txt", true);
    System.Console.WriteLine("Please enter session ID:");
    int sessionIdString = int.Parse(Console.ReadLine());
    System.Console.WriteLine("Please enter customer name:");
    string name = Console.ReadLine();
    System.Console.WriteLine("Please enter the customers email:");
    string email = Console.ReadLine();
    System.Console.WriteLine("Please enter the date of the session");
    string date = Console.ReadLine();
    System.Console.WriteLine("Please enter the trainer ID:");
    string trainerIdString = Console.ReadLine();
    System.Console.WriteLine("Please enter trainer name:");
    string trainerNameString = Console.ReadLine();
    string statusString = "Booked";
    infile.WriteLine();
    infile.Write(sessionIdString);
    infile.Write("#");
    infile.Write(name);
    infile.Write("#");
    infile.Write(email);
    infile.Write("#");
    infile.Write(date);
    infile.Write("#");
    infile.Write(trainerIdString);
    infile.Write("#");
    infile.Write(trainerNameString);
    infile.Write("#");
    infile.Write(statusString);
    infile.Close();
    return count;
}
static int EditBookingData(string[] sessionID,string[] customerName, string[] customerEmail, string[] trainingDate, string[] trainerID, string[] trainerName, string[] status, int count, string[] copy){
    StreamWriter infile = new StreamWriter("transactions.txt");
    System.Console.WriteLine("Which of these bookings would you like to EDIT:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to edit the booking of {customerName[i]}, listing ID: {sessionID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    infile = new StreamWriter("transactions.txt", true);
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            infile.WriteLine(copy[i]);
        }
    }
    string sessionIdString = sessionID[choice-1];
    string customerNameString = customerName[choice - 1];
    string customerEmailString = customerEmail[choice - 1];
    string trainingDateString = trainingDate[choice - 1];
    string trainerIdString = trainerID[choice -1];
    string trainerNameString = trainerName[choice -1];
    string statusString = status[choice -1];

    //------------------------------- Reworking the edited line
    while(1 == 1){
        while(1 == 1){
            System.Console.WriteLine("What would you like to edit:");
            System.Console.WriteLine($"1- Session ID, current: {sessionIdString}");
            System.Console.WriteLine($"2- Customer Name, current: {customerNameString}");
            System.Console.WriteLine($"3- Customer Email, current: {customerEmailString}");
            System.Console.WriteLine($"4- Training Date, current: {trainingDateString}");
            System.Console.WriteLine($"5- Trainer ID, current: {trainerIdString}");
            System.Console.WriteLine($"6- Trainer Name, current: {trainerNameString}");
            System.Console.WriteLine($"7- Training Status, current: {statusString}");
            System.Console.WriteLine("8- Return to Menu");
            choice = 0;
            choice = int.Parse(Console.ReadLine());
            if((choice == 1) || (choice == 2) || (choice == 3) || (choice == 4) || (choice == 5) || (choice == 6) || (choice == 7) || (choice ==8)){
                break;
            }
            else{
                System.Console.WriteLine("Error. Invalid Response.");
            }
        }
        if(choice == 1){
            System.Console.WriteLine("Please enter new Session ID:");
            sessionIdString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 2){
            System.Console.WriteLine("Please enter new customer name:");
            customerNameString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 3){
            System.Console.WriteLine("Please enter new customer email:");
            customerEmailString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 4){
            System.Console.WriteLine("Please enter new training date:");
            trainingDateString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 5){
            System.Console.WriteLine("Please enter new trainer ID:");
            trainerIdString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 6){
            System.Console.WriteLine("Please enter new trainer name:");
            trainerNameString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 7){
            System.Console.WriteLine("Please enter new training status:");
            statusString = Console.ReadLine();
            System.Console.WriteLine("");
        }
        if(choice == 8){
            break;
        }
    }
    //Paste back edited line
    infile.Write(sessionIdString);
    infile.Write("#");
    infile.Write(customerNameString);
    infile.Write("#");
    infile.Write(customerEmailString);
    infile.Write("#");
    infile.Write(trainingDateString);
    infile.Write("#");
    infile.Write(trainerIdString);
    infile.Write("#");
    infile.Write(trainerNameString);
    infile.Write("#");
    infile.Write(statusString);
    infile.Close();
    return count;
}
static int DeleteBookingData(string[] sessionID,string[] customerName, string[] customerEmail, string[] trainingDate, string[] trainerID, string[] trainerName, string[] status, int count, string[] copy){
    StreamWriter infile = new StreamWriter("transactions.txt");
    System.Console.WriteLine("Which of these customer bookings would you like to DELETE:");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Enter {i+1} to delete the booking of {customerName[i]}, Session ID: {sessionID[i]}");
    }
    int choice = int.Parse(Console.ReadLine());
    infile.Write("");
    infile.Close();
    int hasTyped = 0;
    for(int i = 0;(i < count); i++){
        if(i != choice-1){
            if(hasTyped == 0){
                infile = new StreamWriter("transactions.txt");
                infile.WriteLine(copy[i]);
                infile.Close();
                hasTyped = 1;
            }
            else if(((i == count - 2) && (choice==count)) || (i == count - 1)){
                infile = new StreamWriter("transactions.txt", true);
                infile.Write(copy[i]);
                infile.Close();
            }
            else if(hasTyped == 1){
                infile = new StreamWriter("transactions.txt", true);
                infile.WriteLine(copy[i]);
                infile.Close();
            }

        }

    }
    infile.Close(); 
    return count-1;

}
static void RunReports(){
    while(1 == 1){
        System.Console.WriteLine("Which of these reports would you like to compile:");
        System.Console.WriteLine("1- Search transactions by filter");
        System.Console.WriteLine("2- Historical Customer Sessions");
        System.Console.WriteLine("3- Historical Revenue Report");
        System.Console.WriteLine("4- Return to menu");
        int choice = int.Parse(Console.ReadLine());
        if(choice == 1){
            runIndividualCustomerSessions();
            break;
        }
        if(choice == 2){
            runHistoricalCustomerSessions();
            break;
        }

        if(choice == 3){
            runHistoricalRevenueReport();
            break;
        }
        if(choice ==4){
            break;
        }
    }
}
static void runIndividualCustomerSessions(){
    int count = 0;
    int indexChoice;
    string searchFilter = "";
    //Select search filter
    while(1 == 1){
        int choice = 0;
        System.Console.WriteLine("Which of these would you like to search by:");
        System.Console.WriteLine("1- Email");
        System.Console.WriteLine("2- Customer Name");
        System.Console.WriteLine("3- Training Date");
        System.Console.WriteLine("4- Trainer Name");
        choice = int.Parse(Console.ReadLine());
        if(choice == 1){
            indexChoice = 2;
            System.Console.WriteLine("Please enter email to search for:");
            searchFilter = Console.ReadLine();
            break;
        }
        else if(choice == 2){
            indexChoice = 1;
            System.Console.WriteLine("Please enter customer name to search by:");
            searchFilter = Console.ReadLine();
            break;
        }
        else if(choice == 3){
            indexChoice = 3;
            System.Console.WriteLine("Please enter training date to search for:");
            searchFilter = Console.ReadLine();
            break;
        }
        else if(choice == 4){
            indexChoice = 5;
            System.Console.WriteLine("Please enter trainer name to search for:");
            searchFilter = Console.ReadLine();
            break;
        }
    }

    //Actual Search
    System.Console.WriteLine("");
    StreamReader infile = new StreamReader("transactions.txt");
    string line = infile.ReadLine(); //priming read
    while(line != null){
        string[] temp = line.Split("#");
        if(temp[indexChoice] == searchFilter){
            count++;
            System.Console.WriteLine($"Session ID: {temp[0]}, Customer Name: {temp[1]}");
            System.Console.WriteLine($"Training Date: {temp[3]}, Trainer ID: {temp[4]}, Trainer Name: {temp[5]}");
            System.Console.WriteLine($"Status: {temp[6]}");
            System.Console.WriteLine("");
        }
        line = infile.ReadLine(); //update read
    }
    System.Console.WriteLine("");
    infile.Close();
}
static void runHistoricalCustomerSessions(){
    int[] day = new int[600];
    int[] month = new int[600];
    int[] year = new int[600];
    string[] customer = new string[600];
    string[] temp2 = new string[30];
    int temp3;
    string tempString;
    StreamReader infile = new StreamReader("transactions.txt");
    string line = infile.ReadLine(); //priming read
    int count = 0;
    while(line != null){
        string[] temp = line.Split("#");
        string date = temp[3];
        temp2 = date.Split("/");
        day[count] = int.Parse(temp2[0]);
        month[count] = int.Parse(temp2[1]);
        year[count] = int.Parse(temp2[2]);
        customer[count] = (temp[1]);
        count = count + 1;
        line = infile.ReadLine();
        }
    //sort
    int count2 = 0;
    while(count2 != count-1){
        if(string.Compare(customer[count2], customer[count2+1]) == -1){
            count2 = count2+1;
        }
        else if(string.Compare(customer[count2], customer[count2+1]) == 1){
            tempString = customer[count2];
            customer[count2] = customer[count2+1];
            customer[count2+1] = tempString;
            temp3 = year[count2];
            year[count2] = year[count2+1];
            year[count2+1] = temp3;
            temp3 = month[count2];
            month[count2] = month[count2+1];
            month[count2+1] = temp3;
            temp3 = day[count2];
            day[count2] = day[count2+1];
            day[count2+1] = temp3;
            count2 = 0;
        }
        else if(string.Compare(customer[count2], customer[count2+1]) == 0){
            if(year[count2] > year[count2+1]){
                count2 = count2 + 1;
            }
            else if(year[count2] < year[count2+1]){
                tempString = customer[count2];
                customer[count2] = customer[count2+1];
                customer[count2+1] = tempString;
                temp3 = year[count2];
                year[count2] = year[count2+1];
                year[count2+1] = temp3;
                temp3 = month[count2];
                month[count2] = month[count2+1];
                month[count2+1] = temp3;
                temp3 = day[count2];
                day[count2] = day[count2+1];
                day[count2+1] = temp3;
                count2 = 0;
            }
            else if(year[count2] == year[count2+1]){
                if(month[count2] > month[count2+1]){
                    count2 = count2 + 1;
                }
                else if(month[count2] == (month[count2+1])){
                    if(day[count2] > day[count2+1]){
                        count2 = count2 + 1;
                    }
                    else if(day[count2] < day[count2+1]){
                        tempString = customer[count2];
                        customer[count2] = customer[count2+1];
                        customer[count2+1] = tempString;
                        temp3 = year[count2];
                        year[count2] = year[count2+1];
                        year[count2+1] = temp3;
                        temp3 = month[count2];
                        month[count2] = month[count2+1];
                        month[count2+1] = temp3;
                        temp3 = day[count2];
                        day[count2] = day[count2+1];
                        day[count2+1] = temp3;
                        count2 = 0;
                    }
                    else if(day[count2] == day[count2+1]){
                            count2 = count2 + 1;
                    }
                   //----------------------------
                }
                //Onedrive/desktop/mis221/pa5
                else if(month[count2] < month[count2+1]){
                    tempString = customer[count2];
                    customer[count2] = customer[count2+1];
                    customer[count2+1] = tempString;
                    temp3 = year[count2];
                    year[count2] = year[count2+1];
                    year[count2+1] = temp3;
                    temp3 = month[count2];
                    month[count2] = month[count2+1];
                    month[count2+1] = temp3;
                    temp3 = day[count2];
                    day[count2] = day[count2+1];
                    day[count2+1] = temp3;
                    count2 = 0;
                }
            } 
        }
    }
    System.Console.WriteLine("");
    for(int i = 0; i < count; i++){
        System.Console.WriteLine($"Customer: {customer[i]}, Date: {day[i]}/{month[i]}/{year[i]}");

    }

    System.Console.WriteLine("");
    infile.Close();
}
static void runHistoricalRevenueReport(){
    int[] month = new int[600];
    int[] year = new int[600];
    int[] revenue = new int[600];
    string[] temp2 = new string[30];
    string line = "";
    int temp3;
    StreamReader infile = new StreamReader("listings.txt");
    line = infile.ReadLine(); //priming read
    int count = 0;
    while(line != null){
        string[] temp = line.Split("#");
        string date = temp[2];
        temp2 = date.Split("/");
        month[count] = int.Parse(temp2[1]);
        year[count] = int.Parse(temp2[2]);
        revenue[count] = int.Parse(temp[4]);
        count = count + 1;
        line = infile.ReadLine();
        }
    //sort
    int count2 = 0;
    int count3 = count;
    while(count2 != count){
        if(year[count2] > year[count2+1]){
            count2 = count2 + 1;
        }
        else if(year[count2] < year[count2+1]){
            temp3 = year[count2];
            year[count2] = year[count2+1];
            year[count2+1] = temp3;
            temp3 = month[count2];
            month[count2] = month[count2+1];
            month[count2+1] = temp3;
            temp3 = revenue[count2];
            revenue[count2] = revenue[count2+1];
            revenue[count2+1] = temp3;
            count2 = 0;
        }
        else if((year[count2] == 0) && (year[count2+1] == 0)){
            break;
        }
        else if(year[count2] == year[count2+1]){
            if(month[count2] > month[count2+1]){
                count2 = count2 + 1;
            }
            else if(month[count2] == (month[count2+1])){
                revenue[count2] =+ revenue[count2+1];
                revenue[count2+1] = 0;
                month[count2+1] = 0;
                year[count2+1] = 0;
                count3 = count3 - 1;
                count2 = 0;
            }
            //Onedrive/desktop/mis221/pa5
            else if(month[count2] < month[count2+1]){
                temp3 = year[count2];
                year[count2] = year[count2+1];
                year[count2+1] = temp3;
                temp3 = month[count2];
                month[count2] = month[count2+1];
                month[count2+1] = temp3;
                temp3 = revenue[count2];
                revenue[count2] = revenue[count2+1];
                revenue[count2+1] = temp3;
                count2 = 0;
            }
        } 
    }
    System.Console.WriteLine("");
    for(int i = 0; i < count3; i++){
        if(year[i] != 0){
        System.Console.WriteLine($"{month[i]}/{year[i]}, Revenue: {revenue[i]}");
    }
    }
    System.Console.WriteLine("");
    infile.Close();
    }


//-----------------------------------------------------------------
//Main menu
//I was not sure as to date format, so I programmed this as day/month/year 
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
    string[] sessionID = new string[6000];
    string[] customerName = new string[6000];
    string[] customerEmail = new string[6000];
    string[] trainingDate = new string[6000];
    string[] trainerID2  = new string[6000];
    string[] trainerName2 = new string[6000];
    string[] status = new string[6000];
    System.Console.WriteLine("Which would you like to do:");
    System.Console.WriteLine("1- Manage Trainer Data");
    System.Console.WriteLine("2- Manage Listing Data");
    System.Console.WriteLine("3- Manage Customer Booking Data");
    System.Console.WriteLine("4- Run Report");
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
        ManageCustomerBookings(sessionID, customerName, customerEmail, trainingDate, trainerID2, trainerName2, status);
    }
    else if(menuChoice == 4){
        RunReports();
    }
    else if(menuChoice == 5){
        break;
    }

}
