using DotnetApi1.Models;

namespace DotnetApi1.Services
{
    public class PostService
    {
        private static readonly List<Post> AllPosts = new List<Post>();
        private static readonly Post[] AllPostsArr = new Post[50];

        public void CreatePost(Post post)
        {
            AllPosts.Add(post);
        }
        public Task<Post?> GetPost(int id)
        {
            Post thePost = AllPosts.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(thePost);
        }
        public Task<List<Post>> GetAllPosts()
        {
            return Task.FromResult(AllPosts);
        }
    }
}
