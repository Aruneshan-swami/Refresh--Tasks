using EMS.Controllers;
using EMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;

namespace EMS.Tests
{
    public class UnitTest1
    {
    private string baseUrl;
    private WebApplicationFactory<StudentController> students;
    private HttpClient client;
    public UnitTest1()
    {
        students = new WebApplicationFactory<StudentController>();
        baseUrl = "http://localhost:5144/api/Student/";
    }

    [SetUp]
    public void LoadResource()
    {
       client = students.CreateClient();
    }


        [Test]
        public async Task Testing_View()
        {
            int Id = 3;

            var response = await this.client.GetAsync($"{baseUrl}GetStudent/{Id}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                Student StudentContent = JsonConvert.DeserializeObject<Student>(content)!;

                Assert.That(StudentContent!.Id, Is.EqualTo(Id));
            }
            else
            {
                Assert.Fail();
            }

        }



        [Test]
        public async Task Test_AddStudents()
        {
        var content = new
        {
            name ="Arun",
            grade=  "A",
            age= 17,
            gender= "Male"
        };
        var response = await this.client.PostAsJsonAsync($"{baseUrl}AddStudent", content);

        TestContext.WriteLine($"Response : \n{response.StatusCode.ToString()}\n");

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }
}

}





