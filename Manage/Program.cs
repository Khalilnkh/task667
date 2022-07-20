


using Core.Constant;
using Core.Entities;
using Core.Entities.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manage

{
    public class Program
    {
        static void Main()
        {
            GroupRepository _groupRepository = new GroupRepository();
            
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Welcome");
            Console.WriteLine("-----");

            while (true)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Groups");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group by name");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                Console.WriteLine("-----");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result=int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber>=0 && selectedNumber<=5)
                    {
                        switch (selectedNumber)
                        {
                            case (int)Options.CreateGroup:
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name:");
                                string name=Console.ReadLine();
                               maxsize: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Maxsize:");
                                string size=Console.ReadLine();
                                int maxsize;
                                result= int.TryParse(size, out maxsize);
                                if (result)
                                {
                                    Group group = new Group 
                                    { 
                                        Name=name,
                                        MaxSize=maxsize
                                    
                                    };
                                    var createdGroup=_groupRepository.Create(group);
                                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name } is successfully created with max size {createdGroup.MaxSize}");

                                }
                                else
                                {
                                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct group maxsize:");
                                    goto maxsize;
                                }

                                break;
                            case (int)Options.UpdateGroup:
                                break;
                            case (int)Options.DeleteGroup:
                                break;
                            case (int)Options.AllGroups:
                                var groups=_groupRepository.GetAll();
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups");
                                foreach (var group in groups)
                                {
                                    Console.WriteLine($"Name;{group.Name} Maxsize {group.MaxSize}");
                                }
                                break;
                            case (int)Options.GetGroupByName:
                                break;
                            case (int)Options.Exit:
                                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Thanks for using our accplication");
                                return;
                           
                        }

                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");

                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                }
            }

            

            




        }

    }
}