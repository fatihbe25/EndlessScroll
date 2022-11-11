namespace PostAPI.Model
{
    public class Data
    {

        public Data()
        {
            posts = new List<string>();
        }

        private List<string> posts;

        public List<string> Posts
        {
            get { return posts; }
            set { posts = value; }
        }

        public void Add(string post)
        {
            Posts.Add(post);
        }

        public void Remove(string post)
        {
            var ix = Posts.FindIndex(r => r == post);
            if (ix >= 0)
                Posts.RemoveAt(ix);
        }

    }
}
