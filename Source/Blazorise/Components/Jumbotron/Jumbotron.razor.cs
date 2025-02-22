﻿#region Using directives
using Blazorise.Utilities;
using Microsoft.AspNetCore.Components;
#endregion

namespace Blazorise
{
    /// <summary>
    /// Lightweight, flexible component for showcasing hero unit style content.
    /// </summary>
    public partial class Jumbotron : BaseComponent
    {
        #region Members

        private Background background = Background.None;

        #endregion

        #region Methods

        /// <inheritdoc/>
        protected override void BuildClasses( ClassBuilder builder )
        {
            builder.Append( ClassProvider.Jumbotron() );
            builder.Append( ClassProvider.JumbotronBackground( Background ), Background != Background.None );

            base.BuildClasses( builder );
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the jumbotron contextual background color.
        /// </summary>
        [Parameter]
        public Background Background
        {
            get => background;
            set
            {
                background = value;

                DirtyClasses();
            }
        }

        /// <summary>
        /// Gets or sets the reference to the parent <see cref="Jumbotron"/> component.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        #endregion
    }
}
