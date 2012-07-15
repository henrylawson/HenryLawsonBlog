using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Data
{
    public class ArticleCollection : IArticleCollection
    {
        public IList<Article> Entries
        {
            get
            {
                return new[]
                    {
new Article 
{
    Title = "The Magic Number", 
    Date = new DateTime(2012, 6, 1),
    Body = @"
<p>There is no magic number for test coverage but this doesn’t mean a magic number shouldn’t be set. Setting a project wide minimum coverage standard that breaks the build can be useful in a Continuous Integration environment.</p> 
<p>The significance of the chosen minimum coverage standard must be understood by all team members and they must be aware that this coverage minimum is not permanent. It is merely a minimum standard that all future tests should aim for. A marker in the sand that represents the teams current coverage standard. A standard that anyone on the team can change, at any time.</p>
<p>If new code is developed that brings the code base below this minimum standard, when it is checked in it will break the build. It forces the developers to ask the question “Why is this new section of code receiving a lower coverage than the current project minimum standard?”. If the answer is because inadequate tests have been written, then the minimum coverage standard has served its purpose. If the answer to the question is that this new piece of functionality is untestable or too difficult to test then a quick huddle can be had amongst the developers and the test can be improved or the standard can be lowered as that piece of functionality will hopefully be tested at a higher level (integration, functional, manual, etc). The important aspects in both situations is that a conversation was had and that developers were forced to think about the “thoroughness” of their tests. </p>
<p>To reiterate further, if the answer to the question had been that the new functionality being checked in contains a large amount of DTO’s with large amounts of simple properties that don’t need to be tested, then lowering the standard for this circumstance might be ok. The important point to note is that by setting a standard and having it enforced through a direct form of feedback such as making it a part of the projects Continuous Integration process stimulates conversation and ensures that all developers are making conscious decisions about the tests they are writing or <em>not</em> writing. The quick huddles that occur also provides transparency to other developers so they are kept in the loop about parts of the project they may not be working on and the direction those parts are taking.</p>
"
},
new Article
{
    Title = "Counting Points at Dev Done",
    Date = new DateTime(2012, 06, 04), 
    Body = @"
<p>Counting points at developer done is a touchy and controversial topic. I recently engaged in this discussion with my team and we reached an interesting conclusion. The typical way to count points for a story is when that story has passed through QA, automated functional or acceptance tests are written, all outstanding bugs are resolved and all issues on it have been fixed, this final stage is known as QA done. It is only at this final stage that traditionally the points for the story are counted towards the team's velocity. In my team we were counting the points at when the story was developer done, that is, we were counting points when the developer has just finished work on the story and hands it over to QA to be reviewed. </p>
<p>After much debate amongst the team we finally came to the conclusion (after some very wise words from a senior member of our team) that it didn’t really matter.</p>
<p>Our attention was brought back to one of the purposes of counting points. One fo the purposes of counting points is to communicate progress. If the client and team have a shared understanding of what is being used to quantify that progress and it is being quantified in a consistent manner - at developer done - then counting points at developer done is fine. The reason for this is that everyone is on the same page as to what it means when 10 points is added to the velocity, that is 10 developer done points. In our case, our client and us both knew we were counting points at developer done so we decided it wasn’t a problem. However it came with a few other conditions.</p>
<p>We agreed that counting points at developer done is ok, provided that there are no extreme fluctuations in the amount of work that is required post developer done. This includes the effort spent through volleyball, the effort being spent by QA’s to test and also the effort spent by developers fixing those QA found bugs. We decided that if there was a large fluctuation in that time such that it begins to lean towards more work being done post developer done then this sort of counting process should be reviewed. The reason for this is that there is going to be a large amount of effort being undertaken post the points of a story being counted done and this is going to have a large knock on effect in project planning. So with that decided, we continued counting points at developer done.</p>
"
}
                    };
            }
        }
    }
}