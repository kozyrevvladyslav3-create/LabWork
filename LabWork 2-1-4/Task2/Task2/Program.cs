namespace Task2
{
    public struct Comment
    {
        public string AuthorNickname { get; }
        public string Text { get; }
        public DateTime CreatedAt { get; }

        public Comment(string authorNickname, string text)
        {
            AuthorNickname = authorNickname;
            Text = text;
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{CreatedAt:dd.MM.yyyy HH:mm}] {AuthorNickname}: {Text}";
        }
    }

    public class Post
    {
        private static int _idCounter = 1;
        public int Id { get; }
        public DateTime CreatedAt { get; }
        public string Text { get; set; }
        public int LikesCount { get; private set; }
        public List<Comment> Comments { get; }

        public Post(string text)
        {
            Id = _idCounter++;
            CreatedAt = DateTime.Now;
            Text = text;
            LikesCount = 0;
            Comments = new List<Comment>();
        }

        public void AddLike()
        {
            LikesCount++;
        }

        public void AddComment(string authorNickname, string text)
        {
            Comments.Add(new Comment(authorNickname, text));
        }

        public void DisplayPostInfo()
        {
            Console.WriteLine($"Пост ID: {Id} | Дата: {CreatedAt:dd.MM.yyyy HH:mm:ss}");
            Console.WriteLine($"Текст: {Text}");
            Console.WriteLine($"Лайків: {LikesCount}");
            Console.WriteLine($"Коментарі ({Comments.Count}):");
            if (Comments.Count == 0)
            {
                Console.WriteLine("  (немає коментарів)");
            }
            else
            {
                foreach (var comment in Comments)
                {
                    Console.WriteLine($"  {comment}");
                }
            }
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public List<Post> Posts { get; }

        public User(string name, string email, string nickname)
        {
            Name = name;
            Email = email;
            Nickname = nickname.StartsWith("@") ? nickname : "@" + nickname;
            Posts = new List<Post>();
        }
        public void CreatePost(string text)
        {
            Post newPost = new Post(text);
            Posts.Add(newPost);
            Console.WriteLine($"{Nickname} створив новий пост (ID: {newPost.Id})!");
        }
        public bool DeletePost(int postId)
        {
            Post postToRemove = Posts.FirstOrDefault(p => p.Id == postId);
            if (postToRemove != null)
            {
                Posts.Remove(postToRemove);
                Console.WriteLine($"Пост з ID {postId} успішно видалено користувачем {Nickname}.");
                return true;
            }
            Console.WriteLine($"Пост з ID {postId} не знайдено у користувача {Nickname}.");
            return false;
        }
        public void ViewTargetUserLatestPosts(User targetUser)
        {
            Console.WriteLine($"\n=== {Nickname} переглядає стрічку {targetUser.Nickname} ===");
            var latestPosts = targetUser.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Take(5)
                .ToList();

            if (latestPosts.Count == 0)
            {
                Console.WriteLine($"У користувача {targetUser.Nickname} ще немає постів.");
                return;
            }

            foreach (var post in latestPosts)
            {
                post.DisplayPostInfo();
            }
        }
        public void LikePost(User targetUser, int postId)
        {
            Post post = targetUser.Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.AddLike();
                Console.WriteLine($"{Nickname} лайкнув пост (ID: {postId}) користувача {targetUser.Nickname}!");
            }
            else
            {
                Console.WriteLine($"Пост з ID {postId} у користувача {targetUser.Nickname} не знайдено.");
            }
        }
        public void CommentPost(User targetUser, int postId, string commentText)
        {
            Post post = targetUser.Posts.FirstOrDefault(p => p.Id == postId);
            if (post != null)
            {
                post.AddComment(this.Nickname, commentText);
                Console.WriteLine($"{Nickname} прокоментував пост (ID: {postId}) користувача {targetUser.Nickname}.");
            }
            else
            {
                Console.WriteLine($"Пост з ID {postId} у користувача {targetUser.Nickname} не знайдено.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User alice = new User("Аліса", "alice@email.com", "@alice");
            User bob = new User("Bob", "bob@email.com", "@bob");
            User volodya = new User("Володя", "volodya@email.com", "@volodya");
            bob.CreatePost("ben");
            bob.CreatePost("bob the builder");
            bob.CreatePost("bentley");
            alice.CreatePost("Подорожую. Надіюсь, погода буде гарною.");
            System.Threading.Thread.Sleep(500);
            volodya.CreatePost("Мій перший пост!");
            volodya.CreatePost("Пост 2");
            volodya.CreatePost("Пост 3");
            volodya.CreatePost("Пост 4");
            volodya.CreatePost("Пост 5 (Свіжий)");
            volodya.CreatePost("Пост 6 (Найновіший - має увійти в топ-5)");
            Console.WriteLine();
            alice.ViewTargetUserLatestPosts(volodya);
            alice.LikePost(bob, 2);
            volodya.CommentPost(bob, 2, "da");
            alice.CommentPost(bob, 2, "fnnuy");
            volodya.ViewTargetUserLatestPosts(bob);
            bob.DeletePost(1);
            alice.ViewTargetUserLatestPosts(bob);
        }
    }
}
