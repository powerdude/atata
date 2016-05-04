﻿using _ = Atata.Tests.SelectPage;

namespace Atata.Tests
{
    [NavigateTo("http://localhost:50549/Select.html")]
    [VerifyTitle("Select")]
    public class SelectPage : Page<_>
    {
        [TermSettings(TermFormat.Title)]
        public enum Option
        {
            [Term("--select--")]
            None,
            OptionA,
            OptionB,
            OptionC,
            OptionD
        }

        [Term(CutEnding = false)]
        public Select<_> TextSelect { get; private set; }

        [Term("Text Select", CutEnding = false)]
        [Format("Option {0}")]
        public Select<_> FormattedTextSelect { get; private set; }

        [Term("Text Select", CutEnding = false)]
        [SelectByText]
        public Select<Option, _> EnumSelectByText { get; private set; }

        [Term("Text Select", CutEnding = false)]
        [SelectByValue(TermFormat.Pascal)]
        public Select<Option, _> EnumSelectByValue { get; private set; }

        [Term("Int Select", CutEnding = false)]
        [SelectByText(StringFormat = "0{0}")]
        public Select<int, _> IntSelectByText { get; private set; }

        [Term("Int Select", CutEnding = false)]
        [SelectByValue]
        public Select<int, _> IntSelectByValue { get; private set; }
    }
}