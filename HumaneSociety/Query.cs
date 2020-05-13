using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {        
        static HumaneSocietyDataContext db;

        static Query()
        {
            db = new HumaneSocietyDataContext();
        }

        internal static List<USState> GetStates()
        {
            List<USState> allStates = db.USStates.ToList();       

            return allStates;
        }
            
        internal static Client GetClient(string userName, string password)
        {
            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.City = null;
                newAddress.USStateId = stateId;
                newAddress.Zipcode = zipCode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            // find corresponding Client from Db
            Client clientFromDb = null;

            try
            {
                clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("No clients have a ClientId that matches the Client passed in.");
                Console.WriteLine("No update have been made.");
                return;
            }
            
            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.City = null;
                newAddress.USStateId = clientAddress.USStateId;
                newAddress.Zipcode = clientAddress.Zipcode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }
        
        internal static void AddUsernameAndPassword(Employee employee)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeeFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return employeeFromDb;
            }
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName != null;
        }


        //// TODO Items: ////
        
        // TODO: Allow any of the CRUD operations to occur here
        internal static void RunEmployeeQueries(Employee employee, string crudOperation)
        {
            switch (crudOperation)
            {
                case "create":
                    AddEmployee(employee);      // no UserName, Password included.
                    break;
                case "read":
                    DisplayEmployee(employee);   // employee only contains EmployeeNumber
                    break;
                case "update":
                    UpdateEmployee(employee);   // no UserName, Password included
                    break;
                case "delete":
                    DeleteEmployee(employee);   // LastName and EmployeeNumber is given
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        internal static void AddEmployee(Employee employee)      // no UserName, Password included.
        {

        }

        internal static void DisplayEmployee(Employee employee)   // employee only contains EmployeeNumber
        {

        }

        internal static void UpdateEmployee(Employee employee)   // no UserName, Password included
        {

        }

        internal static void DeleteEmployee(Employee employee)   // LastName and EmployeeNumber is given
        {

        }

        // TODO: Animal CRUD Operations
        internal static void AddAnimal(Animal animal)
        {
            db.Animals.InsertOnSubmit(animal);

            db.SubmitChanges();
        }

        internal static Animal GetAnimalByID(int id)
        {
            Animal animalFromDb = db.Animals.Where(a => a.AnimalId == id).Single();

            return animalFromDb;
        }

        internal static void UpdateAnimal(int animalId, Dictionary<int, string> updates)
        {
            Animal animalFromDb = null;

            try
            {
                animalFromDb = db.Animals.Where(a => a.AnimalId == animalId).Single();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("No animals have an AnimalId that matches the AnimalId passed in.");
                Console.WriteLine("No updates have been made.");
                return;
            }

            UpdateAnimal(animalFromDb, updates);
            // submit changes
            db.SubmitChanges();
        }

        internal static void UpdateAnimal(Animal animalFromDb, Dictionary<int, string> updates)
        {
            foreach (KeyValuePair<int, string> update in updates)
            {
                switch (update.Key)
                {
                    case 1:
                        animalFromDb.CategoryId = GetCategoryId(update.Value);
                        break;
                    case 2:
                        animalFromDb.Name = update.Value;
                        break;
                    case 3:
                        animalFromDb.Age = int.Parse(update.Value);
                        break;
                    case 4:
                        animalFromDb.Demeanor = update.Value;
                        break;
                    case 5:
                        animalFromDb.KidFriendly = update.Value == "true";
                        break;
                    case 6:
                        animalFromDb.PetFriendly = update.Value == "true";
                        break;
                    case 7:
                        animalFromDb.Weight = int.Parse(update.Value);
                        break;
                    default:
                        throw new InvalidOperationException();
                        break;
                }
            }
        }

        internal static void RemoveAnimal(Animal animal)
        {
            Animal animalFromDb = GetAnimalByID(animal.AnimalId);

            if (animalFromDb != null)
            {
                // Remove all references to this animal from db.
                RemoveRoom(animalFromDb.AnimalId);
                RemoveShots(animalFromDb);
                Adoption adoptionFromDb = GetAdoption(animalFromDb.AnimalId);
                if (adoptionFromDb != null)
                    RemoveAdoption(adoptionFromDb.AnimalId, adoptionFromDb.ClientId);

                db.Animals.DeleteOnSubmit(animalFromDb);
                db.SubmitChanges();
            }
        }
        
        // TODO: Animal Multi-Trait Search
        internal static IQueryable<Animal> SearchForAnimalsByMultipleTraits(Dictionary<int, string> updates) // parameter(s)?
        {
            throw new NotImplementedException();

            //var animalsFromDb = db.Animals.Where();

            //foreach (KeyValuePair<int, string> update in updates)
            //{
            //    switch (update.Key)
            //    {
            //        case 1:
            //            searchParameters.Add(1, GetStringData("category", "the animal's"));
            //            break;
            //        case 2:
            //            searchParameters.Add(2, GetStringData("name", "the animal's"));
            //            break;
            //        case 3:
            //            searchParameters.Add(3, GetIntegerData("age", "the animal's").ToString());
            //            break;
            //        case 4:
            //            searchParameters.Add(4, GetStringData("demeanor", "the animal's"));
            //            break;
            //        case 5:
            //            searchParameters.Add(5, GetBitData("the animal", "kid friendly").ToString());
            //            break;
            //        case 6:
            //            searchParameters.Add(6, GetBitData("the animal", "pet friendly").ToString());
            //            break;
            //        case 7:
            //            searchParameters.Add(7, GetIntegerData("weight", "the animal's").ToString());
            //            break;
            //        case 8:
            //            searchParameters.Add(8, GetIntegerData("ID", "the animal's").ToString());
            //            break;
            //        default:
            //            throw new InvalidOperationException();
            //            break;
            //    }
            //}
        }

        // TODO: Misc Animal Things
        internal static int GetCategoryId(string categoryName)
        {
            try
            {
                var categoryFromDb = db.Categories.Where(c => c.Name == categoryName).Single();
                return categoryFromDb.CategoryId;
            }
            catch (InvalidOperationException e)
            { 
                throw new InvalidOperationException();
            }
        }

        internal static Room GetRoom(int animalId)
        {
            Room roomFromDb = db.Rooms.Where(r => r.AnimalId == animalId).Single();

            return roomFromDb;
        }

        internal static void RemoveRoom(int animalId)
        {
            Room roomFromDb = GetRoom(animalId);

            if (roomFromDb != null)
            {
                db.Rooms.DeleteOnSubmit(roomFromDb);
                db.SubmitChanges();
            }
        }

        internal static int GetDietPlanId(string dietPlanName)
        {
            try
            { 
                var dietPlanFromDb = db.DietPlans.Where(dp => dp.Name == dietPlanName).Single();
                return dietPlanFromDb.DietPlanId;
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException();
            }
        }

        // TODO: Adoption CRUD Operations
        internal static void Adopt(Animal animal, Client client)
        {
            Adoption newAdoption = new Adoption();

            newAdoption.ClientId = client.ClientId;
            newAdoption.AnimalId = animal.AnimalId;
            newAdoption.ApprovalStatus = "Pending";
            newAdoption.AdoptionFee = 75;
            newAdoption.PaymentCollected = false;

            animal.AdoptionStatus = "Pending";

            db.Adoptions.InsertOnSubmit(newAdoption);
            db.SubmitChanges();
        }

        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            return db.Adoptions.Where(a => a.ApprovalStatus == "Pending");
        }

        internal static void UpdateAdoption(bool isAdopted, Adoption adoption)
        {
            Adoption adoptionFromDb = db.Adoptions.Where(a => a.ClientId == adoption.ClientId && a.AnimalId == adoption.AnimalId).Single();

            adoptionFromDb.ApprovalStatus = isAdopted == true ? "Approved" : "Not Approved";

            Animal animalFromDb = db.Animals.Where(a => a.AnimalId == adoptionFromDb.AnimalId).Single();
            animalFromDb.AdoptionStatus = adoptionFromDb.ApprovalStatus;

            db.SubmitChanges();
        }

        internal static void RemoveAdoption(int animalId, int clientId)
        {
            var adoptionFromDb = db.Adoptions.Where(a => a.ClientId == clientId && a.AnimalId == animalId).Single();

            if (adoptionFromDb != null)
            {
                Animal animalFromDb = db.Animals.Where(a => a.AnimalId == animalId).Single();
                animalFromDb.AdoptionStatus = "Not Approved";

                db.Adoptions.DeleteOnSubmit(adoptionFromDb);
                db.SubmitChanges();
            }
        }

        internal static Adoption GetAdoption(int animalId)
        {
            var adoptionFromDb = db.Adoptions.Where(a => a.AnimalId == animalId).Single();

            return adoptionFromDb;
        }

        // TODO: Shots Stuff
        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            return db.AnimalShots.Where(s => s.AnimalId == animal.AnimalId);
        }

        // Adds a shot to the AnimalShots table.
        internal static void UpdateShot(string shotName, Animal animal)
        {
            AnimalShot animalShot = new AnimalShot();
            Shot shotFromDb;

            try
            {
                shotFromDb = db.Shots.Where(s => s.Name == shotName).Single();
            }
            catch (InvalidOperationException e)
            {
                // Add a new shot type
                shotFromDb = new Shot();
                shotFromDb.Name = shotName;
                db.Shots.InsertOnSubmit(shotFromDb);
                db.SubmitChanges();
            }

            animalShot.AnimalId = animal.AnimalId;
            animalShot.ShotId = shotFromDb.ShotId;
            animalShot.DateReceived = DateTime.Now;

            db.AnimalShots.InsertOnSubmit(animalShot);
            db.SubmitChanges();
        }

        internal static void RemoveShots(Animal animal)
        {
            var shots = GetShots(animal);

            foreach (AnimalShot shot in shots.ToList())
            {
                db.AnimalShots.DeleteOnSubmit(shot);
            }

            db.SubmitChanges();
        }
    }
}