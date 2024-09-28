
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

var db = new BlogDbContext();

var doing = true;
var result = new List<Post>();
while (doing)
{
    
    Console.WriteLine("Search data \n 1 - Author \n 2 - Keyword \n 0 - exit");
    int Choice = int.Parse(Console.ReadLine()!);
    


    switch (Choice)
    {
        case 1:
            Console.WriteLine("Enter the Name: ");
            var q = Console.ReadLine();
            result = (from post in db.Posts
                         join author in db.Authors on post.AuthorId equals author.Id
                         where author.Name.Contains(q)
                         select post)
                        .ToList();
            break;
        case 2:
            Console.WriteLine("Enter the keyword: ");
            q = Console.ReadLine();
            result = db.Posts.Where(c => c.Text.Contains(q)).ToList().OrderBy(c => c.AuthorId).ToList();
           
            break;
        case 3:
            doing = false;
            break;
    }
    foreach (var resultItem in result)
    {
        Console.WriteLine(resultItem.Text);
    }
}
















