using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace FeatureToggle.Pages
{
    public class IndexModel : PageModel
    {
        public bool FeatureA { get; set; }
        public bool FeatureB { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IFeatureManager _featureManager;
        private readonly Lazy<ICalculateDiscount> _calculateDiscount;

        public IndexModel(ILogger<IndexModel> logger,
            IFeatureManager featureManager,
            Lazy<ICalculateDiscount> calculateDiscount)
        {
            _logger = logger;
            _featureManager = featureManager;
            _calculateDiscount = calculateDiscount;
        }

        public async void OnGet()
        {
            FeatureA = await _featureManager.IsEnabledAsync("FeatureA");
            if (FeatureA)
            {
                _logger.LogInformation("Calling dependency.");
                _calculateDiscount.Value.ApplyDiscount();
            }
            FeatureB = await _featureManager.IsEnabledAsync("FeatureB");
        }
    }
}
