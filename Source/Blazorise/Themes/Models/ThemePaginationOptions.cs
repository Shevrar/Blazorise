﻿namespace Blazorise
{
    /// <summary>
    /// Defines the theme options for the <see cref="Pagination"/> component.
    /// </summary>
    public record ThemePaginationOptions : ThemeBasicOptions
    {
        /// <summary>
        /// Gets or sets the border radius of the large pagination.
        /// </summary>
        public string LargeBorderRadius { get; set; } = ".3rem";
    }
}
