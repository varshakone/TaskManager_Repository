﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.BusinessLayer.Interface;
using TaskManager.BusinessLayer.Services;
using TaskManager.BusinessLayer.Services.Repository;
using TaskManager.DataLayer;
using TaskManager.Entities;
using TaskManager.Test.Utility;
using Xunit;
using TaskStatus = TaskManager.Entities.TaskStatus;

namespace TaskManager.Test.TestCases
{
    [Collection("parallel")]
    public class ExceptionTest
    {
        // private refernce declaration
        IConfigurationRoot config;
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskService _taskService;
        private MongoDBContext context;
        

        private TaskItem taskItem;
        private TaskGroup taskGroup;
        private String testResult;
        static FileUtility fileUtility;


        static ExceptionTest()
        {
            fileUtility = new FileUtility();
            fileUtility.FilePath = "../../../../output_exception_revised.txt";
            fileUtility.CreateTextFile();
        }

        public ExceptionTest()
        {
            taskGroup = new TaskGroup
            {
                GroupName = "Academic Task",
                Active = "Yes",
                Color = "red"

            };
            taskItem = new TaskItem
            {
                Name = "Training",
                Priority = TaskPriority.High,
                TaskStatus = TaskStatus.Yet_To_Start,
                TaskStartDate = DateTime.Now,
                TaskEndDate = DateTime.Now.AddDays(5),
                TaskGroup = "Academic Task",
                TaskColorCode = "purple"
            };

            MongoDBUtility mongoDBUtility = new MongoDBUtility();
            context = mongoDBUtility.MongoDBContext;

            _taskRepository = new TaskRepository(context);
            _taskService = new TaskService(_taskRepository);
            config = new ConfigurationBuilder().AddJsonFile("appsettings.test.json").Build();


        }

        /// <summary>
        /// test method to check new task added into database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_NewTask_FailWithNullException()
        {
            try
            {
                //_mockCollection.Setup(op => op.InsertOneAsync(taskItem, null,
                //default(CancellationToken))).Returns(Task.CompletedTask);
                //_mockContext.Setup(c => c.GetCollection<TaskItem>(typeof(TaskItem).Name)).Returns(_mockCollection.Object);
                //var taskService = new TaskService(context);

                taskItem = null;
                //Action
                var result =await _taskService.NewTask(taskItem);
               if (result == "New Task Added")
                {
                    testResult = "ExceptionTestFor_NewTask_FailWithNullException=" + "False";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_NewTask_FailWithNullException",
                            expectedOutput = "False",
                            weight = 2,
                            mandatory = "False",
                            desc = "na"
                        };
                        await new FileUtility().WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    // Assert 
                    Assert.Null(result);
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_NewTask_FailWithNullException=" + "True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_NewTask_FailWithNullException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }

        }

        /// <summary>
        /// test method to check new task group added into database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_NewTaskGroup_FailWithException()
        {
            var result = string.Empty;
            try
            {
               
                    MongoDBUtility mongoDBUtility = new MongoDBUtility(new TaskGroup());
                    //_mockContext = mongoDBUtility.MockContext;
                    //_mockCollectionGroup = mongoDBUtility.MockCollectionGroup;
                    //_mockOptions = mongoDBUtility.MockOptions;
                    //context = mongoDBUtility.MongoDBContext;


                    //_mockCollectionGroup.Setup(op => op.InsertOneAsync(taskGroup, null,
                    //default(CancellationToken))).Returns(Task.CompletedTask);
                    //_mockContext.Setup(c => c.GetCollection<TaskGroup>(typeof(TaskGroup).Name)).Returns(_mockCollectionGroup.Object);
                    //var taskService = new TaskService(context);
                     taskGroup = null;
                    //Action
                    result =await _taskService.NewTaskGroup(taskGroup);
                    
                    if (result == "New Group Added")
                    {
                       testResult = "ExceptionTestFor_NewTaskGroup_FailWithException=" + "False";
                      // Write test case result in text file
                        fileUtility.WriteTestCaseResuItInText(testResult);

                        // Write test case result in xml file
                        if (config["env"] == "development")
                        {
                            cases newcase = new cases
                            {
                                TestCaseType = "Exception",
                                Name = "ExceptionTestFor_NewTaskGroup_FailWithException",
                                expectedOutput = "False",
                                weight = 2,
                                mandatory = "False",
                                desc = "na"
                            };
                            await new FileUtility().WriteTestCaseResuItInXML(newcase);
                        }
                    
                }
                else
                {
                    // Assert 
                    Assert.Null( result);
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_NewTaskGroup_FailWithException=" + "True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_NewTaskGroup_FailWithException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }

        }


        /// <summary>
        /// test method to edit task into database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_EditTask_FailWithException()
        {
            try
            {
                
                taskItem = null;
                //Action
                var result =await _taskService.EditTask(taskItem);
                
                if (result != 0)
                {
                    
                    testResult = "ExceptionTestFor_EditTask_FailWithException=" +"False";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_EditTask_FailWithException",
                            expectedOutput = "False",
                            weight = 2,
                            mandatory = "False",
                            desc = "na"
                        };
                        await new FileUtility().WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    // Assert 
                    Assert.Equal(0, result);
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_EditTask_FailWithException=" + "True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_EditTask_FailWithException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }

        }

        /// <summary>
        /// test method to retrieve all task from database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_GetAllTask_FailWithException()
        {
            List<TaskItem> result = null;
            try
            {
                
                //Action
                result =await _taskService.GetAllTask();
              if (result.Count != 0)
                {
                   
                    testResult = "ExceptionTestFor_GetAllTask_FailWithException=" + "False";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_GetAllTask_FailWithException",
                            expectedOutput = "False",
                            weight = 2,
                            mandatory = "False",
                            desc = "na"
                        };
                        await new FileUtility().WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    // Assert 
                    Assert.NotEmpty(result);
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_GetAllTask_FailWithException=" + "True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_GetAllTask_FailWithException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }


        }


        /// <summary>
        /// test method to retrieve task dashboard from database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_GetTaskDashboard_FailWithException()
        {
            TaskDashboard result = null;
            try
            {
                

                //Action
                result =await _taskService.GetDashboard();
                
                if (result ==null && result.TotalGroups == 0 && result.TotalTask == 0 && result.PendingTask == 0 && result.CompletedTask == 0 )
                {
               
                    testResult = "ExceptionTestFor_GetTaskDashboard_FailWithException=" + "False";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_GetTaskDashboard_FailWithException",
                            expectedOutput = "False",
                            weight = 2,
                            mandatory = "False",
                            desc = "na"
                        };
                        await new FileUtility().WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    // Assert 
                    Assert.NotNull(result);
                   
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_GetTaskDashboard_FailWithException=" +"True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_GetTaskDashboard_FailWithException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }

        }

        /// <summary>
        /// test method to retrieve all task group from database throws exception or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ExceptionTestFor_GetAllTaskGroups_FailWithException()
        {
            List<TaskGroup> result = null;
            try
            {
              

                //Action
                result =await _taskService.GetAllTaskGroup();
                
                if (result != null)
                {
                
                    testResult = "ExceptionTestFor_GetAllTaskGroups_FailWithException=" + "False";

                    // Write test case result in text file
                    fileUtility.WriteTestCaseResuItInText(testResult);

                    // Write test case result in xml file
                    if (config["env"] == "development")
                    {
                        cases newcase = new cases
                        {
                            TestCaseType = "Exception",
                            Name = "ExceptionTestFor_GetAllTaskGroups_FailWithException",
                            expectedOutput = "False",
                            weight = 2,
                            mandatory = "False",
                            desc = "na"
                        };
                        await new FileUtility().WriteTestCaseResuItInXML(newcase);
                    }
                }
                else
                {
                    // Assert 
                    Assert.Null(result);
                }

            }
            catch (Exception exception)
            {
                var error = exception;
                testResult = "ExceptionTestFor_GetAllTaskGroups_FailWithException=" + "True";
                // Write test case result in text file
                fileUtility.WriteTestCaseResuItInText(testResult);

                // Write test case result in xml file
                if (config["env"] == "development")
                {
                    cases newcase = new cases
                    {
                        TestCaseType = "Exception",
                        Name = "ExceptionTestFor_GetAllTaskGroups_FailWithException",
                        expectedOutput = "True",
                        weight = 2,
                        mandatory = "True",
                        desc = "na"
                    };
                    await new FileUtility().WriteTestCaseResuItInXML(newcase);
                }

            }

        }
    }
}
