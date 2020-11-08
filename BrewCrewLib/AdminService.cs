//using BrewCrewDB;
//using BrewCrewDB.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Serilog;
//using System;
//using BrewCrewDB.Repos;

//namespace BrewCrewLib
//{
//    public class AdminService: IAdminService
//    {
//        private BeerItemRepo beerItemRepo;
//        public AdminService(IAdminRepo repo)
//        {
//            this.repo = repo;
//        }

//        public void AddBreweryManager(User manager, Brewery brewery)
//        {
//            try 
//            {
//                ManagersJoint mj = new ManagersJoint()
//                {
//                    ID = Guid.NewGuid().ToString(),
//                    BreweryID = brewery.ID,
//                    Brewery = brewery,
//                    UserID = manager.ID,
//                    User = manager
//                };
//                repo.AddBreweryManagerAsync(mj);
//            } catch(Exception e)
//            {
//                Log.Information($"Unable to Add Manager {e.Message}");
//            }
//            Log.Information($"Manager Successfully Added");
            
//        }

//        public List<User> GetAllManagers()
//        {
//            Task<List<User>> managerTask;
//            try 
//            {
//                managerTask = repo.GetAllManagersAsync();
//                Log.Information($"Manager retrieval successful");
//                return managerTask.Result;
//            } catch (Exception e)
//            {
//                Log.Information($"Unable to get all managers {e.Message}");
//                return new List<User>();
//            }
            
//        }
//        public List<Brewery> GetAllBreweries()
//        {

//            List<Brewery> breweryTask;
//            try
//            {
//                breweryTask = repo.GetAllBreweriesAsync();
//                Log.Information($"Brewery retrieval successful");
//                return breweryTask;
//            }
//            catch (Exception e)
//            {
//                Log.Information($"Unable to get all Breweries {e.Message}");
//                return new List<Brewery>();
//            }

//            //Task<List<Brewery>> breweryTask;
//            //try
//            //{
//            //    breweryTask = repo.GetAllBreweriesAsync();
//            //    Log.Information($"Brewery retrieval successful");
//            //    return breweryTask.Result;
//            //}
//            //catch (Exception e)
//            //{
//            //    Log.Information($"Unable to get all Breweries {e.Message}");
//            //    return new List<Brewery>();
//            //}

//        }

//        public Brewery GetBrewerybyId(string breweryId)
//        {
//            try
//            {
//                Brewery brewery = repo.GetBreweryById(breweryId);
//                Log.Information($"Successfully retrieved Brewery with id {breweryId}");
//                return brewery;
//            }
//            catch (Exception e)
//            {
//                Log.Information($"Failed to retrieve brewery with Id{breweryId} - {e.Message}");
//                return new Brewery();
//            }

//        }

//        public void DeleteBreweryById(string breweryId)
//        {
//            try
//            {
//                repo.DeleteBreweryById(breweryId);
//                Log.Information($"Brewery Successfully Removed");
//            }
//            catch (Exception e)
//            {
//                Log.Information($"Unable to Delete Brewery {e.Message}");
//            }


//        }

//        public void DeleteManagerById(string managerId)
//        {
//            try
//            {
//                repo.DeleteManagerById(managerId);
//                Log.Information($"Manager Successfully Removed");
//            }
//            catch (Exception e)
//            {
//                Log.Information($"Unable to remove customer{e.Message}");
//            }
//        }
//    }
//}