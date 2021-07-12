using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Three_Tier.Service;
using NUnit.Framework;
using Three_Tier.Model;

namespace Three_Tier
{
    class TestMothed
    {
        public MemberService _memberService;

        /// <summary>
        ///  正常情況不應該拿資料庫測試，因為要練習三層式架構
        ///  及 未來可以練習抽換 Repo 才先這樣做
        /// </summary>
        [SetUp]
        public void Init()
        {
            this._memberService = new MemberService();
        }

        /// <summary>
        ///  第一個錯誤地方，使用UOW 卻找不到
        /// 參考文章
        /// https://ithelp.ithome.com.tw/articles/10157700
        /// http://enjoy01coding.blogspot.com/2017/05/aspnet-mvc-entity-framework-repository.html
        /// </summary>
        [Test]
        public void CreateUOW()
        {
            var data = new Member() { Name = "John1221" };
            if (_memberService.CreateUOW(data))
            {
                Console.WriteLine("更新成功");
            }
        }

        [Test]
        public void CreateMember()
        {
            var data = new Member() { Name = "John"};
            if (_memberService.Create(data))
            {
                Console.WriteLine("更新成功");
            }
        }

        [Test]
        public void UpdateMember()
        {
            var r = new Random().Next(0,999);
            var data = new Member()
            {
                Id = 1,
                Name = "Test" + r.ToString()
             };
    
            if(_memberService.Update(data))
            {
                Console.WriteLine("更新成功");
            }
        }

        [Test]
        public void DeleteMember()
        {
       
            var data = new Member(){Id = 2};

            if (_memberService.Delete(data))
            {
                Console.WriteLine("刪除成功");
            }
        }

        [Test]
        public void GetAllMember()
        {
            var data = _memberService.FindAll(x => x.Id > 0);
            foreach (var member in data.ToList())
            {
                Console.WriteLine(@"ID={0}，Name={1}", member.Id, member.Name);
            }
        }


    }
}
