namespace Fulma

open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
type Screen =
    | All
    | Desktop
    | Tablet
    | Mobile
    | WideScreen
    | Touch
    | FullHD

    static member toString =
        function
        | All -> ""
        | Desktop -> "-desktop"
        | Tablet -> "-tablet"
        | Mobile -> "-mobile"
        | WideScreen -> "-widescreen"
        | Touch -> "-touch"
        | FullHD -> "-fullhd"

[<AutoOpen>]
module Color =

    module Classes =
        let [<Literal>] IsBlack = "is-black"
        let [<Literal>] IsDark = "is-dark"
        let [<Literal>] IsLight = "is-light"
        let [<Literal>] IsWhite = "is-white"
        let [<Literal>] IsPrimary = "is-primary"
        let [<Literal>] IsInfo = "is-info"
        let [<Literal>] IsSuccess = "is-success"
        let [<Literal>] IsWarning = "is-warning"
        let [<Literal>] IsDanger = "is-danger"
        let [<Literal>] IsLink = "is-link"
        let [<Literal>] IsBlackBis = "is-black-bis"
        let [<Literal>] IsBlackTer = "is-black-ter"
        let [<Literal>] IsGreyDarker = "is-grey-darker"
        let [<Literal>] IsGreyDark = "is-grey-dark"
        let [<Literal>] IsGrey = "is-grey"
        let [<Literal>] IsGreyLight = "is-grey-light"
        let [<Literal>] IsGreyLighter = "is-grey-lighter"
        let [<Literal>] IsWhiteTer = "is-white-ter"
        let [<Literal>] IsWhiteBis = "is-white-bis"

    type IColor =
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | IsLink
        | IsBlackBis
        | IsBlackTer
        | IsGreyDarker
        | IsGreyDark
        | IsGrey
        | IsGreyLight
        | IsGreyLighter
        | IsWhiteTer
        | IsWhiteBis
        /// Allow you to specify a custom color. The color will be prefixed by "is-"
        | IsCustomColor of string
        /// Allow you to specify a NoColor case.
        | NoColor

    let ofColor level =
        match level with
        | IsBlack -> Classes.IsBlack
        | IsDark -> Classes.IsDark
        | IsLight -> Classes.IsLight
        | IsWhite -> Classes.IsWhite
        | IsPrimary -> Classes.IsPrimary
        | IsInfo -> Classes.IsInfo
        | IsSuccess -> Classes.IsSuccess
        | IsWarning -> Classes.IsWarning
        | IsDanger -> Classes.IsDanger
        | IsLink -> Classes.IsLink
        | IsBlackBis -> Classes.IsBlackBis
        | IsBlackTer -> Classes.IsBlackTer
        | IsGreyDarker -> Classes.IsGreyDarker
        | IsGreyDark -> Classes.IsGreyDark
        | IsGrey -> Classes.IsGrey
        | IsGreyLight -> Classes.IsGreyLight
        | IsGreyLighter -> Classes.IsGreyLighter
        | IsWhiteTer -> Classes.IsWhiteTer
        | IsWhiteBis -> Classes.IsWhiteBis
        | IsCustomColor color -> "is-" + color
        | NoColor -> ""

[<AutoOpen>]
module Size =

    module Classes =
        let [<Literal>] IsSmall = "is-small"
        let [<Literal>] IsMedium = "is-medium"
        let [<Literal>] IsLarge = "is-large"

    type ISize =
        | IsSmall
        | IsMedium
        | IsLarge

    let ofSize size =
        match size with
        | IsSmall -> Classes.IsSmall
        | IsMedium -> Classes.IsMedium
        | IsLarge -> Classes.IsLarge

[<RequireQualifiedAccess>]
module TextSize =
    type Option =
        | Is1
        | Is2
        | Is3
        | Is4
        | Is5
        | Is6
        | Is7

        static member toString =
            function
            | Is1 -> "1"
            | Is2 -> "2"
            | Is3 -> "3"
            | Is4 -> "4"
            | Is5 -> "5"
            | Is6 -> "6"
            | Is7 -> "7"

    let inline generic screen size =
        "is-size-" + Option.toString size + Screen.toString screen

    let inline only screen size =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-size-" + Option.toString size + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-size-xxx-only`." + string x)
            ""

[<RequireQualifiedAccess>]
module TextAlignment =

    module Classes =
        /// Makes the text centered
        let [<Literal>] HasTextCentered = "has-text-centered"
        /// Makes the text justified
        let [<Literal>] HasTextJustified = "has-text-justified"
        /// Makes the text aligned to the left
        let [<Literal>] HasTextLeft = "has-text-left"
        /// Makes the text aligned to the right
        let [<Literal>] HasTextRight = "has-text-right"

    type Option =
        /// Add `has-text-centered`
        | Centered
        /// Add `has-text-justified`
        | Justified
        /// Add `has-text-left`
        | Left
        /// Add `has-text-right`
        | Right

        static member toString =
            function
            | Centered -> Classes.HasTextCentered
            | Justified -> Classes.HasTextJustified
            | Left -> Classes.HasTextLeft
            | Right -> Classes.HasTextRight

    let inline generic screen alignment =
        Option.toString alignment + Screen.toString screen

    let inline only screen alignment =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            Option.toString alignment + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-size-xxx-only`." + string x)
            ""

[<RequireQualifiedAccess>]
module TextWeight =

    module Classes =
        let [<Literal>] HasTextWeightLight = "has-text-weight-light"
        let [<Literal>] HasTextWeightNormal = "has-text-weight-normal"
        let [<Literal>] HasTextWeightSemibold = "has-text-weight-semibold"
        let [<Literal>] HasTextWeightBold = "has-text-weight-bold"

    type Option =
        /// Add `has-text-weight-light`
        | Light
        /// Add `has-text-weight-normal`
        | Normal
        /// Add `has-text-weight-semi-bold`
        | SemiBold
        /// Add `has-text-weight-bold`
        | Bold

    let internal ofOption =
        function
        | Light -> Classes.HasTextWeightLight
        | Normal -> Classes.HasTextWeightNormal
        | SemiBold -> Classes.HasTextWeightSemibold
        | Bold -> Classes.HasTextWeightBold

[<RequireQualifiedAccess>]
module TextTransform =

    module Classes =
        let [<Literal>] IsCapitalized = "is-capitalized"
        let [<Literal>] IsLowercase = "is-lowercase"
        let [<Literal>] IsUppercase = "is-uppercase"
        let [<Literal>] IsItalic = "is-italic"

    type Option =
        /// Add `is-capitalized`
        | Capitalized
        /// Add `is-lowercase`
        | LowerCase
        /// Add `is-uppercase`
        | UpperCase
        /// Add `is-italic`
        | Italic

        static member inline toClass =
            function
            | Capitalized -> Classes.IsCapitalized
            | LowerCase -> Classes.IsLowercase
            | UpperCase -> Classes.IsUppercase
            | Italic -> Classes.IsItalic

[<RequireQualifiedAccess>]
module Display =

    type Option =
        | Block
        | Flex
        | Inline
        | InlineBlock
        | InlineFlex

        static member inline toClass =
            function
            | Block -> "block"
            | Flex -> "flex"
            | Inline -> "inline"
            | InlineBlock -> "inline-block"
            | InlineFlex -> "inline-flex"

    let internal toDisplayClass screen display =
        let display = Option.toClass display
        let screen = Screen.toString screen

        "is-" + display + screen

    let internal toDisplayOnlyClass screen display =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            let display = Option.toClass display
            let screen = Screen.toString screen
            "is-" + display + screen + "-only"

        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support display only." + string x)
            ""

[<RequireQualifiedAccess>]
module Modifier =

    module Classes =
        module BackgroundColor =
            let [<Literal>] Black = "has-background-black"
            let [<Literal>] Dark = "has-background-dark"
            let [<Literal>] Light = "has-background-light"
            let [<Literal>] White = "has-background-white"
            let [<Literal>] Primary = "has-background-primary"
            let [<Literal>] Info = "has-background-info"
            let [<Literal>] Success = "has-background-success"
            let [<Literal>] Warning = "has-background-warning"
            let [<Literal>] Danger = "has-background-danger"
            let [<Literal>] Link = "has-background-link"
            let [<Literal>] BlackBis = "has-background-black-bis"
            let [<Literal>] BlackTer = "has-background-black-ter"
            let [<Literal>] GreyDarker = "has-background-grey-darker"
            let [<Literal>] GreyDark = "has-background-grey-dark"
            let [<Literal>] Grey = "has-background-grey"
            let [<Literal>] GreyLight = "has-background-grey-light"
            let [<Literal>] GreyLighter = "has-background-grey-lighter"
            let [<Literal>] WhiteTer = "has-background-white-ter"
            let [<Literal>] WhiteBis = "has-background-white-bis"
        module TextColor =
            let [<Literal>] Black = "has-text-black"
            let [<Literal>] Dark = "has-text-dark"
            let [<Literal>] Light = "has-text-light"
            let [<Literal>] White = "has-text-white"
            let [<Literal>] Primary = "has-text-primary"
            let [<Literal>] Info = "has-text-info"
            let [<Literal>] Success = "has-text-success"
            let [<Literal>] Warning = "has-text-warning"
            let [<Literal>] Danger = "has-text-danger"
            let [<Literal>] Link = "has-text-link"
            let [<Literal>] BlackBis = "has-text-black-bis"
            let [<Literal>] BlackTer = "has-text-black-ter"
            let [<Literal>] GreyDarker = "has-text-grey-darker"
            let [<Literal>] GreyDark = "has-text-grey-dark"
            let [<Literal>] Grey = "has-text-grey"
            let [<Literal>] GreyLight = "has-text-grey-light"
            let [<Literal>] GreyLighter = "has-text-grey-lighter"
            let [<Literal>] WhiteTer = "has-text-white-ter"
            let [<Literal>] WhiteBis = "has-text-white-bis"

        module Helpers =
            let [<Literal>] IsClearfix = "is-clearfix"
            let [<Literal>] IsPulledLeft = "is-pulled-left"
            let [<Literal>] IsPulledRight = "is-pulled-right"
            let [<Literal>] IsMarginless = "is-marginless"
            let [<Literal>] IsPaddingless = "is-paddingless"
            let [<Literal>] IsOverlay = "is-overlay"
            let [<Literal>] IsClipped = "is-clipped"
            let [<Literal>] IsRadiusless = "is-radiusless"
            let [<Literal>] IsShadowless = "is-shadowless"
            let [<Literal>] IsUnselectable = "is-unselectable"

    let internal ofBackground level =
        match level with
        | IsBlack -> Classes.BackgroundColor.Black
        | IsDark -> Classes.BackgroundColor.Dark
        | IsLight -> Classes.BackgroundColor.Light
        | IsWhite -> Classes.BackgroundColor.White
        | IsPrimary -> Classes.BackgroundColor.Primary
        | IsInfo -> Classes.BackgroundColor.Info
        | IsSuccess -> Classes.BackgroundColor.Success
        | IsWarning -> Classes.BackgroundColor.Warning
        | IsDanger -> Classes.BackgroundColor.Danger
        | IsLink -> Classes.BackgroundColor.Link
        | IsBlackBis -> Classes.BackgroundColor.BlackBis
        | IsBlackTer -> Classes.BackgroundColor.BlackTer
        | IsGreyDarker -> Classes.BackgroundColor.GreyDarker
        | IsGreyDark -> Classes.BackgroundColor.GreyDark
        | IsGrey -> Classes.BackgroundColor.Grey
        | IsGreyLight -> Classes.BackgroundColor.GreyLight
        | IsGreyLighter -> Classes.BackgroundColor.GreyLighter
        | IsWhiteTer -> Classes.BackgroundColor.WhiteTer
        | IsWhiteBis -> Classes.BackgroundColor.WhiteBis
        | IsCustomColor color -> "has-background-" + color
        | NoColor -> ""

    let internal ofText level =
        match level with
        | IsBlack -> Classes.TextColor.Black
        | IsDark -> Classes.TextColor.Dark
        | IsLight -> Classes.TextColor.Light
        | IsWhite -> Classes.TextColor.White
        | IsPrimary -> Classes.TextColor.Primary
        | IsInfo -> Classes.TextColor.Info
        | IsSuccess -> Classes.TextColor.Success
        | IsWarning -> Classes.TextColor.Warning
        | IsDanger -> Classes.TextColor.Danger
        | IsLink -> Classes.TextColor.Link
        | IsBlackBis -> Classes.TextColor.BlackBis
        | IsBlackTer -> Classes.TextColor.BlackTer
        | IsGreyDarker -> Classes.TextColor.GreyDarker
        | IsGreyDark -> Classes.TextColor.GreyDark
        | IsGrey -> Classes.TextColor.Grey
        | IsGreyLight -> Classes.TextColor.GreyLight
        | IsGreyLighter -> Classes.TextColor.GreyLighter
        | IsWhiteTer -> Classes.TextColor.WhiteTer
        | IsWhiteBis -> Classes.TextColor.WhiteBis
        | IsCustomColor color -> "has-text-" + color
        | NoColor -> ""

    let internal ofInvisible screen =
        "is-invisible" + Screen.toString screen

    let internal ofHidden screen =
        "is-hidden" + Screen.toString screen

    let internal ofInvisibleOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-invisible" + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-invisible-xxx-only`." + string x)
            ""

    let internal ofHiddenOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-hidden" + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-hidden-xxx-only`." + string x)
            ""

    type IModifier =
        | BackgroundColor of IColor
        | TextColor of IColor
        | TextWeight of TextWeight.Option
        | TextSize of Screen * TextSize.Option
        | TextSizeOnly of Screen * TextSize.Option
        | TextAlignment of Screen * TextAlignment.Option
        | TextAlignmentOnly of Screen * TextAlignment.Option
        | TextTransform of TextTransform.Option
        | Display of Screen * Display.Option
        | DisplayOnly of Screen * Display.Option
        | IsClearfix
        | IsPulledLeft
        | IsPulledRight
        | IsMarginless
        | IsPaddingless
        | IsOverlay
        | IsClipped
        | IsRadiusless
        | IsShadowless
        | IsUnselectable
        | IsInvisible of Screen * bool
        | IsHidden of Screen * bool
        | IsInvisibleOnly of Screen * bool
        | IsHiddenOnly of Screen * bool

    type internal Options =
        { BackgroundColor : string option
          TextColor : string option
          TextWeight : string option
          TextSize : string
          TextSizeOnly : string
          TextAlignment : string
          TextAlignmentOnly : string
          TextTransform : string
          IsClearfix : string option
          IsPulledLeft : string option
          IsPulledRight : string option
          IsMarginless : string option
          IsPaddingless : string option
          IsOverlay : string option
          IsClipped : string option
          IsRadiusless : string option
          IsShadowless : string option
          IsUnselectable : string option
          IsInvisible : string
          IsHidden : string
          IsInvisibleOnly : string
          IsHiddenOnly : string
          Display : string
          DisplayOnly : string }

        static member Empty =
            { BackgroundColor = None
              TextColor = None
              TextWeight = None
              TextSize = ""
              TextSizeOnly = ""
              TextAlignment = ""
              TextAlignmentOnly = ""
              IsClearfix = None
              IsPulledLeft = None
              IsPulledRight = None
              IsMarginless = None
              IsPaddingless = None
              IsOverlay = None
              IsClipped = None
              IsRadiusless = None
              IsShadowless = None
              IsUnselectable = None
              TextTransform = ""
              IsInvisible = ""
              IsHidden = ""
              IsInvisibleOnly = ""
              IsHiddenOnly = ""
              Display = ""
              DisplayOnly = "" }

    let parseModifiers options =
        let parseOption result opt =
            match opt with
            | BackgroundColor color -> { result with BackgroundColor = color |> ofBackground |> Some }
            | TextColor color -> { result with TextColor = color |> ofText |> Some }
            | TextWeight textWeight -> { result with TextWeight = textWeight |> TextWeight.ofOption |> Some }
            | TextSize (screen, size) -> { result with TextSize = result.TextSize + " " + TextSize.generic screen size }
            | TextSizeOnly (screen, size) -> { result with TextSize = result.TextSize + " " + TextSize.only screen size }
            | TextAlignment (screen, size) -> { result with TextAlignment = result.TextAlignment + " " + TextAlignment.generic screen size }
            | TextAlignmentOnly (screen, size) -> { result with TextAlignment = result.TextAlignment + " " + TextAlignment.only screen size }
            | TextTransform transform -> { result with TextTransform = result.TextTransform + " " + TextTransform.Option.toClass transform }
            | Display (screen, display) ->
                let cls = Display.toDisplayClass screen display
                { result with Display = result.Display + " " + cls }
            | DisplayOnly (screen, display) ->
                let cls = Display.toDisplayOnlyClass screen display
                { result with DisplayOnly = result.DisplayOnly + " " + cls }
            | IsClearfix -> { result with IsClearfix = Classes.Helpers.IsClearfix |> Some }
            | IsPulledLeft -> { result with IsPulledLeft = Classes.Helpers.IsPulledLeft |> Some }
            | IsPulledRight -> { result with IsPulledRight = Classes.Helpers.IsPulledRight |> Some }
            | IsMarginless -> { result with IsMarginless = Classes.Helpers.IsMarginless |> Some }
            | IsPaddingless -> { result with IsPaddingless = Classes.Helpers.IsPaddingless |> Some }
            | IsOverlay -> { result with IsOverlay = Classes.Helpers.IsOverlay |> Some }
            | IsClipped -> { result with IsClipped = Classes.Helpers.IsClipped |> Some }
            | IsRadiusless -> { result with IsRadiusless = Classes.Helpers.IsRadiusless |> Some }
            | IsShadowless -> { result with IsShadowless = Classes.Helpers.IsShadowless |> Some }
            | IsUnselectable -> { result with IsUnselectable = Classes.Helpers.IsUnselectable |> Some }
            | IsInvisible (screen, true) -> { result with IsInvisible = result.IsInvisible + " " + ofInvisible screen }
            | IsInvisible (_, false) -> result
            | IsHidden (screen, true) -> { result with IsHidden = result.IsHidden + " " + ofHidden screen }
            | IsHidden (_, false) -> result
            | IsInvisibleOnly (screen, true) -> { result with IsInvisibleOnly = result.IsInvisibleOnly + " " + ofInvisible screen }
            | IsInvisibleOnly (_, false) -> result
            | IsHiddenOnly (screen, true) -> { result with IsHiddenOnly = result.IsHiddenOnly + " " + ofHidden screen }
            | IsHiddenOnly (_, false) -> result

        let opts = options |> List.fold parseOption Options.Empty
        [ opts.BackgroundColor
          opts.TextColor
          opts.TextWeight
          Some opts.TextSize
          Some opts.TextSizeOnly
          Some opts.TextAlignment
          Some opts.TextAlignmentOnly
          Some opts.TextTransform
          opts.IsClearfix
          opts.IsPulledLeft
          opts.IsPulledRight
          opts.IsMarginless
          opts.IsPaddingless
          opts.IsOverlay
          opts.IsClipped
          opts.IsRadiusless
          opts.IsShadowless
          opts.IsUnselectable
          Some opts.IsInvisible
          Some opts.IsHidden
          Some opts.IsInvisibleOnly
          Some opts.IsHiddenOnly
          Some opts.Display
          Some opts.DisplayOnly ]

[<AutoOpen>]
module Common =
    type GenericOption =
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type GenericOptions =
        { CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }

        static member Empty =
            { CustomClass = None
              Props = []
              Modifiers = [] }

    let genericParse options =
        let parseOptions (result: GenericOptions ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        options |> List.fold parseOptions GenericOptions.Empty

    module Helpers =

        let classes std (options : string option list) (booleans: (string * bool) list) =
            let std = (std, options) ||> List.fold (fun complete opt ->
                match opt with Some name -> complete + " " + name | None -> complete)
            (std, booleans) ||> List.fold (fun complete (name, flag) ->
                if flag then complete + " " + name else complete)
            |> ClassName :> IHTMLProp

[<RequireQualifiedAccess>]
module Text =
    open Fable.Helpers.React

    let p (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes "" ( opts.CustomClass::opts.Modifiers ) []
        p (classes::opts.Props) children

    let div (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes "" ( opts.CustomClass::opts.Modifiers ) []
        div (classes::opts.Props) children

    let span (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes "" ( opts.CustomClass::opts.Modifiers ) []
        span (classes::opts.Props) children
