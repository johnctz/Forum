using Forum.Data;
using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class ForumRepository : IForumRepository
    {
        ICommonRepository _commonRepository;

        public ForumRepository(
            ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<IList<ForumCategory>> GetCategories()
        {
            return await _commonRepository.GetAll<ForumCategory>();
        }

        public async Task AddCategory(ForumCategory category)
        {
            await _commonRepository.Add(category);
        }
        public async Task AddSubCategory(ForumSubCategory subCategory)
        {
            await _commonRepository.Add(subCategory);
        }

        public async Task AddPost(ForumPost post)
        {
            await _commonRepository.Add(post);
        }



        public async Task<IList<ForumTopic>> GetTopics()
        {
            return await _commonRepository.GetAll<ForumTopic>();
        }


        public async Task AddTopic(ForumTopic topic)
        {
            await _commonRepository.Add(topic);
        }

        
        public async Task<ForumTopic> GetTopicById(Guid topicId)
        {
            return await _commonRepository.Get<ForumTopic>(topicId);
        }
        public async Task DeleteTopic(Guid topicId)
        {
            var topic = await GetTopicById(topicId);
            topic.IsDeleted = true;
        }

        public async Task<ForumCategory> GetCategoryById(Guid categoryId)
        {
            return await _commonRepository.Get<ForumCategory>(categoryId);
        }

        public ICollection<ForumSubCategory> GetSubCategoriesByCategoryId(Guid categoryId)
        {
            return GetCategoryById(categoryId).Result.ForumSubCategories;
        }
        public async Task<bool> SaveChanges()
        {
            return await _commonRepository.SaveAsync();
        }
    }
}
