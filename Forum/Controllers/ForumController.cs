using Forum.Entities;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Controllers
{

    [Route("api/[controller]")]

    public class ForumController : Controller
    {
        IForumRepository _forumRepository;

        public ForumController(
            IForumRepository forumRepository
            )
        {
            _forumRepository = forumRepository;
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _forumRepository.GetCategories();
            return new OkObjectResult(categories);
        }

        [Route("category")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(ForumCategory category)
        {
            await _forumRepository.AddCategory(category);
            if (await _forumRepository.SaveChanges() == true)
            {
                return new OkObjectResult(category);
            }
            return new BadRequestObjectResult(category);
        }

        [Route("topic")]
        [HttpPost]
        public async Task<IActionResult> AddTopic(ForumTopic topic)
        {
            await _forumRepository.AddTopic(topic);
            if (await _forumRepository.SaveChanges() == true)
            {
                return new OkObjectResult(topic);
            }
            return new BadRequestObjectResult(topic);
        }


        [Route("topic")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            await _forumRepository.DeleteTopic(topicId);
            if (await _forumRepository.SaveChanges() == true)
            {
                return new OkObjectResult(topicId);
            }
            return new BadRequestObjectResult(topicId);
        }



        [Route("categories/{categoryId}/subcategories")]
        [HttpGet]
        public IActionResult SubCategories(Guid categoryId)
        {
            var subCategories = _forumRepository.GetSubCategoriesByCategoryId(categoryId);
            return new OkObjectResult(subCategories);
        }






    }
}
