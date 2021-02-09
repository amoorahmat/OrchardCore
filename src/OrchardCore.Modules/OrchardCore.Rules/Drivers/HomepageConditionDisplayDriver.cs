using System;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Rules.Models;
using OrchardCore.Rules.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace OrchardCore.Rules.Drivers
{
    public class HomepageConditionDisplayDriver : DisplayDriver<Condition, HomepageCondition>
    {
        public override IDisplayResult Display(HomepageCondition condition)
        {
            return
                Combine(
                    View("HomepageCondition_Fields_Summary", condition).Location("Summary", "Content"),
                    View("HomepageCondition_Fields_Thumbnail", condition).Location("Thumbnail", "Content")
                );
        }

        public override IDisplayResult Edit(HomepageCondition condition)
        {
            return Initialize<HomepageConditionViewModel>("HomepageCondition_Fields_Edit", model =>
            {
                model.Value = condition.Value;
                model.Condition = condition;
            }).Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(HomepageCondition condition, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(condition, Prefix, x => x.Value);
          
            return Edit(condition);
        }     
    }
}
