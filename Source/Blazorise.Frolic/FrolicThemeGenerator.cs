﻿#region Using directives
using System.Globalization;
using System.Text;
#endregion

namespace Blazorise.Frolic
{
    public class FrolicThemeGenerator : ThemeGenerator
    {
        #region Constructors

        public FrolicThemeGenerator( IThemeCache themeCache )
            : base( themeCache )
        {
        }

        #endregion

        #region Methods

        public override string GenerateVariables( Theme theme )
        {
            Variables["--b-frolic-btn-padding-sm"] = "0.27rem 0.85rem";
            Variables["--b-frolic-btn-padding-lg"] = "0.75rem 2rem";

            return base.GenerateVariables( theme );
        }

        protected override void GenerateBackgroundVariantStyles( StringBuilder sb, Theme theme, string variant )
        {
            sb.Append( $".bg-{variant}" ).Append( "{" )
                .Append( $"background-color: {Var( ThemeVariables.BackgroundColor( variant ) )};" )
                .AppendLine( "}" );

            sb.Append( $".e-face-{variant}" ).Append( "{" )
                .Append( $"background-color: {Var( ThemeVariables.BackgroundColor( variant ) )} !important;" )
                .Append( $"color: {ToHex( Contrast( theme, Var( ThemeVariables.BackgroundColor( variant ) ) ) )} !important;" )
                .AppendLine( "}" );
        }

        protected override void GenerateBorderVariantStyles( StringBuilder sb, Theme theme, string variant )
        {
            sb.Append( $".e-border-{variant}" ).Append( "{" )
                .Append( $"border-color: {Var( ThemeVariables.BackgroundColor( variant ) )} !important;" )
                .AppendLine( "}" );
        }

        protected override void GenerateButtonVariantStyles( StringBuilder sb, Theme theme, string variant, ThemeButtonOptions options )
        {
            var background = Var( ThemeVariables.ButtonBackground( variant ) );
            var border = Var( ThemeVariables.ButtonBorder( variant ) );
            var hoverBackground = Var( ThemeVariables.ButtonHoverBackground( variant ) );
            //var hoverBorder = Var( ThemeVariables.ButtonHoverBorder( variant ) );
            //var activeBackground = Var( ThemeVariables.ButtonActiveBackground( variant ) );
            //var activeBorder = Var( ThemeVariables.ButtonActiveBorder( variant ) );
            var yiqBackground = Var( ThemeVariables.ButtonYiqBackground( variant ) );
            //var yiqHoverBackground = Var( ThemeVariables.ButtonYiqHoverBackground( variant ) );
            //var yiqActiveBackground = Var( ThemeVariables.ButtonYiqActiveBackground( variant ) );
            var boxShadow = Var( ThemeVariables.ButtonBoxShadow( variant ) );

            sb.Append( $".e-btn.{variant}" ).Append( "{" )
                .Append( $"color: {yiqBackground};" )
                .Append( GetGradientBg( theme, background, options?.GradientBlendPercentage ) )
                .Append( $"border-color: {border};" )
                .AppendLine( "}" );

            sb.Append( $".e-btn.{variant}:hover," )
                .Append( $".e-btn.{variant}:focus" )
                .Append( "{" )
                .Append( GetGradientBg( theme, hoverBackground, options?.GradientBlendPercentage ) )
                .Append( $"box-shadow: 0 0 0 {options?.BoxShadowSize ?? ".2rem"} {boxShadow};" )
                .AppendLine( "}" );

            //sb.Append( $".e-btn.{variant}:focus" ).Append( $".e-btn.{variant}.focus" ).Append( "{" )
            //    .Append( $"color: {yiqHoverBackground};" )
            //    .Append( GradientBg( theme, hoverBackground ) )
            //    .Append( $"border-color: {hoverBorder};" )
            //    .Append( $"box-shadow: 0 0 0 {options?.BoxShadowSize ?? ".2rem"} {boxShadow};" )
            //    .AppendLine( "}" );

            //sb.Append( $".e-btn.{variant}.disabled" ).Append( $".e-btn.{variant}:disabled" ).Append( "{" )
            //    .Append( $"color: {yiqBackground};" )
            //    .Append( $"background-color: {background};" )
            //    .Append( $"border-color: {border};" )
            //    .Append( $"box-shadow: 0 0 0 {options?.BoxShadowSize ?? ".2rem"} {boxShadow};" )
            //    .AppendLine( "}" );

            //sb
            //    .Append( $".e-btn.{variant}:not(:disabled):not(.disabled):active," )
            //    .Append( $".e-btn.{variant}:not(:disabled):not(.disabled).active," )
            //    .Append( $".show>.e-btn.{variant}.dropdown-toggle" )
            //    .Append( "{" )
            //    .Append( $"color: {yiqActiveBackground};" )
            //    .Append( $"background-color: {activeBackground};" )
            //    .Append( $"border-color: {activeBorder};" )
            //    .AppendLine( "}" );

            //sb
            //    .Append( $".e-btn.{variant}:not(:disabled):not(.disabled):active:focus," )
            //    .Append( $".e-btn.{variant}:not(:disabled):not(.disabled).active:focus," )
            //    .Append( $".show>.e-btn.{variant}.dropdown-toggle:focus" )
            //    .Append( "{" )
            //    .Append( $"box-shadow: 0 0 0 {options?.BoxShadowSize ?? ".2rem"} {boxShadow}" )
            //    .AppendLine( "}" );
        }

        protected override void GenerateButtonOutlineVariantStyles( StringBuilder sb, Theme theme, string variant, ThemeButtonOptions buttonOptions )
        {
            var color = Var( ThemeVariables.OutlineButtonColor( variant ) );
            //var yiqColor = Var( ThemeVariables.OutlineButtonYiqColor( variant ) );
            //var boxShadow = Var( ThemeVariables.OutlineButtonBoxShadowColor( variant ) );

            sb.Append( $".e-btn.outlined.{variant}" ).Append( "{" )
                .Append( $"color: {color};" )
                .Append( $"background-color: white;" )
                .Append( $"background: white;" )
                .Append( $"border-color: {color};" )
                .AppendLine( "}" );

            sb.Append( $".e-btn.outlined.{variant}:hover," )
                .Append( $".e-btn.outlined.{variant}:focus" )
                .Append( "{" )
                .Append( $"background-color: {color};" )
                .AppendLine( "}" );

            //sb.Append( $".e-btn.outlined.{variant}.disabled" ).Append( $".e-btn.outlined.{variant}:disabled" ).Append( "{" )
            //    .Append( $"color: {color};" )
            //    .Append( $"background-color: transparent;" )
            //    .AppendLine( "}" );

            //sb
            //    .Append( $".e-btn.outlined.{variant}:not(:disabled):not(.disabled):active," )
            //    .Append( $".e-btn.outlined.{variant}:not(:disabled):not(.disabled).active," )
            //    .Append( $".show>.e-btn.outlined.{variant}.dropdown-toggle" )
            //    .Append( "{" )
            //    .Append( $"color: {yiqColor};" )
            //    .Append( $"background-color: {color};" )
            //    .Append( $"border-color: {color};" )
            //    .AppendLine( "}" );

            //sb
            //    .Append( $".e-btn.outlined.{variant}:not(:disabled):not(.disabled):active:focus," )
            //    .Append( $".e-btn.outlined.{variant}:not(:disabled):not(.disabled).active:focus," )
            //    .Append( $".show>.e-btn.outlined.{variant}.dropdown-toggle:focus" )
            //    .Append( "{" )
            //    .Append( $"box-shadow: 0 0 0 2rem {boxShadow};" )
            //    .AppendLine( "}" );
        }

        protected override void GenerateButtonStyles( StringBuilder sb, Theme theme, ThemeButtonOptions options )
        {
            sb.Append( $".e-btn" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            sb.Append( $".e-btn.small" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.SmallBorderRadius, Var( "--b-frolic-btn-padding-sm" ) )};" )
                .AppendLine( "}" );

            sb.Append( $".e-btn.plus" ).Append( "{" )
                .Append( $"padding: {GetBorderRadius( theme, options?.LargeBorderRadius, Var( "--b-frolic-btn-padding-lg" ) )};" )
                .AppendLine( "}" );

            if ( !string.IsNullOrEmpty( options?.Margin ) )
                sb.Append( $".e-btn" ).Append( "{" )
                    .Append( $"margin: {options.Margin};" )
                    .AppendLine( "}" );

            if ( options?.DisabledOpacity != null )
                sb.Append( $".e-btn[disabled]" ).Append( "{" )
                    .Append( $"opacity: {options.DisabledOpacity};" )
                    .AppendLine( "}" );
        }

        protected override void GenerateDropdownStyles( StringBuilder sb, Theme theme, ThemeDropdownOptions options )
        {
            sb.Append( $".drop-items" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            if ( !string.IsNullOrEmpty( theme.ColorOptions?.Primary ) )
            {
                var backgroundColor = ParseColor( theme.ColorOptions.Primary );

                if ( !backgroundColor.IsEmpty )
                {
                    var background = ToHex( backgroundColor );

                    sb.Append( $".drop-item:hover" )
                        .Append( "{" )
                        .Append( GetGradientBg( theme, background, options?.GradientBlendPercentage ) )
                        .AppendLine( "}" );
                }
            }
        }

        protected override void GenerateInputStyles( StringBuilder sb, Theme theme, ThemeInputOptions options )
        {
            sb.Append( $".e-control" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            sb.Append( $".e-control-helper" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            sb.Append( $".e-select" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            if ( !string.IsNullOrEmpty( options?.Color ) )
            {
                sb.Append( $".e-control" ).Append( "{" )
                    .Append( $"color: {options.Color};" )
                    .AppendLine( "}" );

                sb.Append( $".e-control-helper" ).Append( "{" )
                    .Append( $"color: {options.Color};" )
                    .AppendLine( "}" );

                sb.Append( $".e-select" ).Append( "{" )
                    .Append( $"color: {options.Color};" )
                    .AppendLine( "}" );
            }
        }

        protected override void GenerateBadgeVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor )
        {
            var backgroundColor = ParseColor( inBackgroundColor );

            if ( backgroundColor.IsEmpty )
                return;

            var yiqBackgroundColor = Contrast( theme, backgroundColor );

            var background = ToHex( backgroundColor );
            var yiqBackground = ToHex( yiqBackgroundColor );

            sb.Append( $".e-tag.{variant}" ).Append( "{" )
                .Append( $"color: {yiqBackground};" )
                .Append( $"background-color: {background};" )
                .AppendLine( "}" );
        }

        protected override void GenerateSwitchVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor, ThemeSwitchOptions options )
        {
            var backgroundColor = ParseColor( inBackgroundColor );

            if ( backgroundColor.IsEmpty )
                return;

            //var boxShadowColor = Lighten( backgroundColor, options?.BoxShadowLightenColor ?? 25 );
            var disabledBackgroundColor = Lighten( backgroundColor, options?.DisabledLightenColor ?? 50 );

            var background = ToHex( backgroundColor );
            //var boxShadow = ToHex( boxShadowColor );
            var disabledBackground = ToHex( disabledBackgroundColor );

            sb
                .Append( $".e-switch[type=\"checkbox\"].{variant}:checked + label::before," )
                .Append( $".e-switch[type=\"checkbox\"].{variant}:checked + label:before" ).Append( "{" )
                .Append( $"background-color: {background};" )
                .AppendLine( "}" );

            sb
                .Append( $".e-switch[type=\"checkbox\"]:disabled.{variant}:checked + label::before" ).Append( "{" )
                .Append( $"background-color: {disabledBackground};" )
                .AppendLine( "}" );
        }

        protected override void GenerateStepsStyles( StringBuilder sb, Theme theme, ThemeStepsOptions stepsOptions )
        {
            sb
                .Append( $".e-steps .e-step-item.e-step-item-completed::before" ).Append( "{" )
                .Append( $"background-position: left bottom;" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-completed .e-step-item-marker" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.White )};" )
                .Append( $"background-color: {Var( ThemeVariables.StepsItemIconCompleted, Var( ThemeVariables.Color( "success" ) ) )};" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-active.e-step-item-completed .e-step-item-marker," )
                .Append( $".e-steps .e-step-item.e-step-item-active .e-step-item-marker" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.White )};" )
                .Append( $"background-color: {Var( ThemeVariables.StepsItemIconActive, Var( ThemeVariables.Color( "primary" ) ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateStepsVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor, ThemeStepsOptions stepsOptions )
        {
            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant}::before" ).Append( "{" )
                .Append( $"background: linear-gradient(to left, #dbdbdb 50%, {Var( ThemeVariables.VariantStepsItemIcon( variant ) )} 50%);" )
                .Append( $"background-size: 200% 100%;" )
                .Append( $"background-position: right bottom;" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant} .e-step-item-marker" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.VariantStepsItemIconYiq( variant ) )};" )
                .Append( $"background-color: {Var( ThemeVariables.VariantStepsItemIcon( variant ) )};" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant}.e-step-item-completed::before" ).Append( "{" )
                .Append( $"background-position: left bottom;" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant}.e-step-item-completed .e-step-item-marker" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.VariantStepsItemIconYiq( variant ) )};" )
                .Append( $"background-color: {Var( ThemeVariables.VariantStepsItemIcon( variant ) )};" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant}.e-step-item-active::before" ).Append( "{" )
                .Append( $"background-position: left bottom;" )
                .AppendLine( "}" );

            sb
                .Append( $".e-steps .e-step-item.e-step-item-{variant}.e-step-item-active.e-step-item-completed .e-step-item-marker," )
                .Append( $".e-steps .e-step-item.e-step-item-{variant}.e-step-item-active .e-step-item-marker" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.StepsItemIconActiveYiq, Var( ThemeVariables.White ) )} !important;" )
                .Append( $"background-color: {Var( ThemeVariables.StepsItemIconActive, Var( ThemeVariables.Color( "primary" ) ) )} !important;" )
                .Append( $"border-color: {Var( ThemeVariables.StepsItemIconActive, Var( ThemeVariables.Color( "primary" ) ) )} !important;" )
                .AppendLine( "}" );
        }

        protected override void GenerateRatingStyles( StringBuilder sb, Theme theme, ThemeRatingOptions ratingOptions )
        {
            if ( ratingOptions?.HoverOpacity != null )
            {
                sb
                    .Append( $".e-rating .e-rating-item.e-rating-item-hover" ).Append( "{" )
                    .Append( $"opacity: {string.Format( CultureInfo.InvariantCulture, "{0:F1}", ratingOptions.HoverOpacity )};" )
                    .AppendLine( "}" );
            }
        }

        protected override void GenerateRatingVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor, ThemeRatingOptions ratingOptions )
        {
            sb
                .Append( $".e-rating .e-rating-item.e-rating-item-{variant}" ).Append( "{" )
                .Append( $"color: {Var( ThemeVariables.VariantRatingColor( variant ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateAlertVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor, string inBorderColor, string inColor, ThemeAlertOptions options )
        {
            var backgroundColor = ParseColor( inBackgroundColor );
            var borderColor = ParseColor( inBorderColor );
            var textColor = ParseColor( inColor );

            var alertLinkColor = Darken( textColor, 10f );

            var background = ToHex( backgroundColor );
            var border = ToHex( borderColor );
            var text = ToHex( textColor );
            var alertLink = ToHex( alertLinkColor );

            sb.Append( $".e-alert.{variant}" ).Append( "{" )
                .Append( $"color: {text};" )
                .Append( GetGradientBg( theme, background, options?.GradientBlendPercentage ) )
                .Append( $"border-color: {border};" )
                .AppendLine( "}" );

            sb.Append( $".e-alert.{variant}.alert-link" ).Append( "{" )
                .Append( $"color: {alertLink};" )
                .AppendLine( "}" );
        }

        protected override void GenerateTableVariantStyles( StringBuilder sb, Theme theme, string variant, string inBackgroundColor, string inBorderColor )
        {
            var backgroundColor = ParseColor( inBackgroundColor );
            var borderColor = ParseColor( inBorderColor );

            var background = ToHex( backgroundColor );
            var border = ToHex( borderColor );

            sb.Append( $".e-row.{variant}" ).Append( "{" )
                .Append( $"background-color: {background};" )
                .Append( $"border-color: {border};" )
                .AppendLine( "}" );
        }

        protected override void GenerateCardStyles( StringBuilder sb, Theme theme, ThemeCardOptions options )
        {
            sb.Append( $".e-card" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateModalStyles( StringBuilder sb, Theme theme, ThemeModalOptions options )
        {
            sb.Append( $".e-modal-content" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateTabsStyles( StringBuilder sb, Theme theme, ThemeTabsOptions options )
        {
            sb.Append( $".e-tabs" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateProgressStyles( StringBuilder sb, Theme theme, ThemeProgressOptions options )
        {
            sb.Append( $".e-progress" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            base.GenerateProgressStyles( sb, theme, options );
        }

        protected override void GenerateAlertStyles( StringBuilder sb, Theme theme, ThemeAlertOptions options )
        {
            sb.Append( $".e-alert" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );
        }

        protected override void GenerateBreadcrumbStyles( StringBuilder sb, Theme theme, ThemeBreadcrumbOptions options )
        {
            sb.Append( $".e-breadcrumb" ).Append( "{" )
                 .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                 .AppendLine( "}" );

            if ( !string.IsNullOrEmpty( Var( ThemeVariables.BreadcrumbColor ) ) )
            {
                sb.Append( $".e-breadcrumb a" ).Append( "{" )
                    .Append( $"color: {Var( ThemeVariables.BreadcrumbColor )};" )
                    .AppendLine( "}" );
            }
        }

        protected override void GenerateBadgeStyles( StringBuilder sb, Theme theme, ThemeBadgeOptions options )
        {
            sb.Append( $".e-tag:not(.e-tag .rounded)" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );
        }

        protected override void GeneratePaginationStyles( StringBuilder sb, Theme theme, ThemePaginationOptions options )
        {
            sb.Append( $".e-page-item" ).Append( "{" )
                .Append( $"border-radius: {GetBorderRadius( theme, options?.BorderRadius, Var( ThemeVariables.BorderRadius ) )};" )
                .AppendLine( "}" );

            if ( !string.IsNullOrEmpty( theme.ColorOptions?.Primary ) )
            {
                sb.Append( $".e-page-item.on-page" ).Append( "{" )
                    .Append( $"background-color: {theme.ColorOptions.Primary};" )
                    .Append( $"border-color: {theme.ColorOptions.Primary};" )
                    .AppendLine( "}" );
            }
        }

        protected override void GenerateBarStyles( StringBuilder sb, Theme theme, ThemeBarOptions options )
        {
        }

        protected override void GenerateParagraphVariantStyles( StringBuilder sb, Theme theme, string variant, string inTextColor )
        {
            var textColor = ParseColor( inTextColor );

            var textColorHex = ToHex( textColor );

            sb.Append( $".text-{variant}" )
                .Append( "{" )
                .Append( $"color: {textColorHex};" )
                .AppendLine( "}" );
        }

        protected override void GenerateInputVariantStyles( StringBuilder sb, Theme theme, string variant, string inColor )
        {
            var color = ToHex( ParseColor( inColor ) );

            sb.Append( $".e-control.text-{variant}" )
                .Append( "{" )
                .Append( $"color: {color};" )
                .AppendLine( "}" );
        }

        #endregion
    }
}
