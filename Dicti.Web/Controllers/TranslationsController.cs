using Dicti.Data.Models;
using Dicti.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dicti.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationsController : ControllerBase
    {
        [HttpPost]
        public DictiResponse<bool> Add(Translations translation)
        {
            var result = new DictiResponse<bool>() { Data = false };

            try
            {
                var context = new DictiDBContext();
                translation.CreatedOn = DateTime.UtcNow;
                context.Translations.Add(translation);
                context.SaveChanges();
                result.Data = true;
            }
            catch (Exception е)
            {
                result.Data = false;
            }

            return result;
        }

        [HttpGet]
        public DictiResponse<ICollection<Translations>> Get()
        {
            var context = new DictiDBContext();

            //var translationsStatic = new Dictionary<string, string>()
            //    {
            //    { "food", "храна" },
            //    { "football", "футбол" },
            //    { "apple", "ябълка" },
            //    { "cat", "котка" },
            //    { "water", "вода" },
            //    { "phone", "телефон" },
            //    { "ant", "мравка" },
            //    { "ball", "топка" },
            //    { "car", "кола" },
            //    { "doll", "кукла" },
            //    { "bed", "легло" },
            //    { "dog", "куче" },
            //    { "elephant", "слон" },
            //    { "frog", "жаба" },
            //    { "girl", "момиче" },
            //    { "hat", "шапка" },
            //    { "egg", "яйце" },
            //    { "fish", "риба" },
            //    { "glass", "чаша" },
            //    { "hen", "кокошка" },
            //    { "igloo", "иглу" },
            //    { "jacket", "яке" },
            //    { "lorry", "камион" },
            //    { "indian", "иниянец" },
            //    { "jam", "буркан" },
            //    { "kangaroo", "кенгуру" },
            //    { "lemon", "лимон" },
            //    { "parrot", "морков" },
            //    { "baby", "бебе" },
            //    { "train", "влак" },
            //    { "golf", "голф" },
            //    { "volleyball", "волейбол" },
            //    { "socks", "чорапи" },
            //    { "hamburger", "хамбургер" },
            //    { "tree", "дърво" },
            //    { "plane", "самолет" },
            //    { "king", "крал" },
            //    { "box", "кутия" },
            //    { "giraffe", "жираф" },
            //    { "book", "книга" },
            //    { "bike", "колело" },
            //    { "toy", "играчка" },
            //    { "house", "къща" },
            //    { "comic", "комикс" },
            //    { "computer", "компютър" },
            //    { "bird", "птица" },
            //    { "hear", "коса" },
            //    { "mask", "маска" },
            //    { "nest", "гнездо" },
            //    { "ox", "биг" },
            //    { "pen", "химикал" },
            //    { "man", "мъж" },
            //    { "nine", "девет" },
            //    { "orange", "портокал, оранжево" },
            //    { "penguin", "пингвин" },
            //    { "sun", "слънце" },
            //    { "robot", "робот" },
            //    { "queen", "кралица" },
            //    { "question", "въпрос" },
            //    { "rabbit", "заек" },
            //    { "snake", "змия" },
            //    { "coala", "коала" },
            //    { "win", "победа" },
            //    { "research", "иследване" },
            //    { "early", "рано" },
            //    { "food", "храна" },
            //    { "air", "въздух" },
            //    { "foot", "крак" },
            //    { "load", "натоварване" },
            //    { "tribe", "племе" },
            //    { "can", "мога" },
            //    { "flee", "бягам" },
            //    { "ill", "болен" },
            //    { "host", "домакин" },
            //    { "cope", "справям се" },
            //    { "flesh", "плът" },
            //    { "garage", "гараж" },
            //    { "operator", "оператор" },
            //    { "instructor", "инструктор" },
            //    { "collapse", "срутване" },
            //    { "battery", "батерия" },
            //    { "arrival", "пристигане" },
            //    { "inflation", "инфлация" },
            //    { "wood", "дърво" },
            //    { "winter", "зима" },
            //    { "village", "село" },
            //    { "roll", "ролка" },
            //    { "run", "тичам" },
            //    { "gain", "печалба" },
            //    { "communication", "общуване" },
            //    { "sales", "продажба" },
            //    { "resident", "местен, местен жител" },
            //    { "lie", "лъжа" },
            //    { "happy", "щастлив" },
            //    { "eight", "осем" },
            //    { "exactly", "точно" },
            //    { "size", "размер" },
            //    { "sign", "подписвам се" },
            //    { "fries", "картофки" },
            //    { "zoo", "зоологическа градина" },
            //    { "mail", "пощенска кутия" },
            //};

            //foreach (KeyValuePair<string, string> entry in translationsStatic)
            //{
            //    var transalationValues = new List<TransalationValues>() {
            //    new TransalationValues
            //    {
            //        LanguageId = 1,
            //        Text = entry.Key,
            //    },
            //    new TransalationValues
            //    {
            //        LanguageId = 2,
            //        Text = entry.Value,
            //    },
            //    };


            //    var translation = new Translations
            //    {
            //        CreatedOn = DateTime.UtcNow,
            //        TransalationValues = transalationValues
            //    };


            //    context.Translations.Add(translation);
            //    context.SaveChanges();
            //}

            var translations = context.Translations
                .Include(x => x.TransalationValues).ThenInclude(v => v.Language)
                .Where(x => x.IsDeleted.HasValue ? !(bool)x.IsDeleted : true)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return new DictiResponse<ICollection<Translations>>()
            {
                Data = translations
            };
        }
    }
}
