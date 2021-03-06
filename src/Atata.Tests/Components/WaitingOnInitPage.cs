﻿using NUnit.Framework;

namespace Atata.Tests
{
    using _ = WaitingOnInitPage;

    [Url(Url)]
    public class WaitingOnInitPage : Page<_>
    {
        public const string Url = "waitingoninit";

        public enum WaitKind
        {
            None,
            WaitForElementVisible,
            WaitForVisible,
            VerifyExists,
            VerifyMissing
        }

        [FindByClass]
        public Control<_> LoadingBlock { get; private set; }

        [FindByClass]
        public Text<_> ContentBlock { get; private set; }

        public WaitKind OnInitWaitKind { get; set; }

        protected override void OnInit()
        {
            if (OnInitWaitKind == WaitKind.WaitForElementVisible)
                Triggers.Add(new WaitForElementAttribute(WaitBy.Class, "content-block", Until.Visible, TriggerEvents.Init));
            else if (OnInitWaitKind == WaitKind.WaitForVisible)
                ContentBlock.Triggers.Add(new WaitForAttribute(Until.Visible));
            else if (OnInitWaitKind == WaitKind.VerifyExists)
                ContentBlock.Triggers.Add(new VerifyExistsAttribute());
            else if (OnInitWaitKind == WaitKind.VerifyMissing)
                LoadingBlock.Triggers.Add(new VerifyMissingAttribute());
        }

        public _ VerifyContentBlockIsLoaded()
        {
            Assert.That(ContentBlock.GetScope(SearchOptions.UnsafelyAtOnce()).Text, Is.EqualTo("Loaded"));
            return this;
        }
    }
}
