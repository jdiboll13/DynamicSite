using System;
using System.Collections.Generic;
using System.IO;


namespace DynamicSite.Models
{
    public class ReferenceModel
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PostDate { get; set; } = DateTime.Now.ToString();

        public List<ReferenceModel> Builder()
        {
            var commentList = new List<ReferenceModel>();

            using (var reader = new StreamReader(System.IO.File.Open("comments.csv", FileMode.Open)))
                while (reader.Peek() >= 0)
                {
                    var user = reader.ReadToEnd();
                    var data = user.Split(',');
                    for (int i = 0; i < data.Length - 5; i += 5)
                    {
                        var newComment = new ReferenceModel();
                        newComment.Message = data[i];
                        newComment.Name = data[i + 1];
                        newComment.Email = data[i + 2];
                        newComment.Website = data[i + 3];
                        newComment.PostDate = data[i + 4];
                        commentList.Add(newComment);
                    }
                }
            return commentList;
        }
    }
}