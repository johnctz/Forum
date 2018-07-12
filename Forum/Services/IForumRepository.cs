using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forum.Entities;

namespace Forum.Services
{
    public interface IForumRepository
    {
        Task AddCategory(ForumCategory category);
        Task AddPost(ForumPost post);
        Task AddSubCategory(ForumSubCategory subCategory);
        Task AddTopic(ForumTopic topic);
        Task DeleteTopic(Guid topicId);
        Task<IList<ForumTopic>> GetTopics();
        Task<IList<ForumCategory>> GetCategories();
        Task<ForumCategory> GetCategoryById(Guid categoryId);
        ICollection<ForumSubCategory> GetSubCategoriesByCategoryId(Guid categoryId);
        Task<ForumTopic> GetTopicById(Guid topicId);
        Task<bool> SaveChanges();
    }
}