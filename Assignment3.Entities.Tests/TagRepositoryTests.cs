using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Assignment3.Core;
using static Assignment3.Core.Response; 

namespace Assignment3.Entities.Tests;


public class TagRepositoryTests
{
    private readonly KanbanContext context;
    private readonly TagRepository repository;

    public TagRepositoryTests()
    {
        //TODO: Fix connection string
        var connection = new SqlConnection("Server=localhost;Database=msdb;User Id=sa;Password=Pamcr.microsoft.com/mssql/server:2019-latestw0rd2022;Trusted_Connection=False;Encrypt=False");
        connection.Open();
        var builder = new DbContextOptionsBuilder<KanbanContext>();
        builder.UseSqlite(connection);
        var _context = new KanbanContext(builder.Options);
        _context.Database.EnsureCreated();


        var tag1 = new Tag { id = 1, name = "TODO", tasks = new List<Task>() };
        var tag2 = new Tag { id = 2, name = "Bug", tasks = new List<Task>() };
        var task1 = new Task { id = 1, title = "Make Hello World", tags = new List<Tag>(){tag1}, state = State.New };
        tag1.tasks.Add(task1);

        _context.Tags.AddRange(tag1, tag2);
        _context.Tasks.Add(task1);
        _context.SaveChanges();

        context = _context;
        repository = new TagRepository(context);
    }

    [Fact]
    public void Given_new_tag_returns_tag()
    {
        var (response, tagId) = repository.Create(new TagCreateDTO ("New Tag"));
        response.Should().Be(Created);
    }
}
