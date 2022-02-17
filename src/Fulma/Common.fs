namespace Fulma

open Fable.React
open Fable.React.Props

module Reflection =

    open Microsoft.FSharp.Reflection
    open System

    let getCaseName (case : 'T) =
#if FABLE_COMPILER
        Fable.Core.Reflection.getCaseName case
#else
        // Get UnionCaseInfo value from the F# reflection tools
        let (caseInfo, _args) = FSharpValue.GetUnionFields(case, typeof<'T>)
        caseInfo.GetCustomAttributes()
        |> Seq.tryPick (function
                        | :? CompiledNameAttribute as att -> Some att.CompiledName
                        | _ -> None)
        |> Option.defaultWith (fun () -> caseInfo.Name)
#endif

    let getCaseTag (case : 'T) =
#if FABLE_COMPILER
        Fable.Core.Reflection.getCaseTag case
#else
        let (caseInfo, _args) = FSharpValue.GetUnionFields(case, typeof<'T>)
        caseInfo.Tag
#endif

[<RequireQualifiedAccess>]
type Screen =
    | All
    | [<CompiledName("desktop")>] Desktop
    | [<CompiledName("tablet")>] Tablet
    | [<CompiledName("mobile")>] Mobile
    | [<CompiledName("widescreen")>] WideScreen
    | [<CompiledName("touch")>] Touch
    | [<CompiledName("fullhd")>] FullHD

    static member ToString (screen : Screen) =
        match screen with
        | All -> ""
        | Desktop
        | Tablet
        | Mobile
        | WideScreen
        | Touch
        | FullHD -> "-" + Reflection.getCaseName screen

[<AutoOpen>]
module Color =

    type IColor =
        | [<CompiledName("is-black")>] IsBlack
        | [<CompiledName("is-dark")>] IsDark
        | [<CompiledName("is-light")>] IsLight
        | [<CompiledName("is-white")>] IsWhite
        | [<CompiledName("is-primary")>] IsPrimary
        | [<CompiledName("is-info")>] IsInfo
        | [<CompiledName("is-success")>] IsSuccess
        | [<CompiledName("is-warning")>] IsWarning
        | [<CompiledName("is-danger")>] IsDanger
        | [<CompiledName("is-link")>] IsLink
        | [<CompiledName("is-black-bis")>] IsBlackBis
        | [<CompiledName("is-black-ter")>] IsBlackTer
        | [<CompiledName("is-grey-darker")>] IsGreyDarker
        | [<CompiledName("is-grey-dark")>] IsGreyDark
        | [<CompiledName("is-grey")>] IsGrey
        | [<CompiledName("is-grey-light")>] IsGreyLight
        | [<CompiledName("is-grey-lighter")>] IsGreyLighter
        | [<CompiledName("is-white-ter")>] IsWhiteTer
        | [<CompiledName("is-white-bis")>] IsWhiteBis
        /// Allow you to specify a custom color. The color will be prefixed by "is-"
        | IsCustomColor of string
        /// Allow you to specify a NoColor case.
        | NoColor

    let ofColor level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "is-" + color
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
        | IsWhiteBis -> Reflection.getCaseName level

[<AutoOpen>]
module Size =

    type ISize =
        | [<CompiledName("is-small")>] IsSmall
        | [<CompiledName("is-medium")>] IsMedium
        | [<CompiledName("is-large")>] IsLarge

    let inline ofSize size =
        Reflection.getCaseName size

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

        static member ToString (x: Option) =
            Reflection.getCaseTag x + 1 |> string

    let inline generic screen size =
        "is-size-" + Option.ToString size + Screen.ToString screen

    let inline only screen size =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-size-" + Option.ToString size + Screen.ToString screen + "-only"
        | x ->
            Fable.Core.JS.console.warn(sprintf "Screen `%s` does not support `is-size-xxx-only`." (string x))
            ""

[<RequireQualifiedAccess>]
module TextAlignment =

    type Option =
        /// Add `has-text-centered`
        | [<CompiledName("has-text-centered")>] Centered
        /// Add `has-text-justified`
        | [<CompiledName("has-text-justified")>] Justified
        /// Add `has-text-left`
        | [<CompiledName("has-text-left")>] Left
        /// Add `has-text-right`
        | [<CompiledName("has-text-right")>] Right

        static member inline ToString opt =
            Reflection.getCaseName opt

    let inline generic screen alignment =
        Option.ToString alignment + Screen.ToString screen

    let inline only screen alignment =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            Option.ToString alignment + Screen.ToString screen + "-only"
        | x ->
            Fable.Core.JS.console.warn(sprintf "Screen `%s` does not support `is-size-xxx-only`." (string x))
            ""

[<RequireQualifiedAccess>]
module FlexDirection =

    type Option =
        /// <summary>Add <c>is-flex-direction-row</c></summary>
        | [<CompiledName("is-flex-direction-row")>] Row
        /// <summary>Add <c>is-flex-direction-row-reverse</c></summary>
        | [<CompiledName("is-flex-direction-row-reverse")>] RowReverse
        /// <summary>Add <c>is-flex-direction-column</c></summary>
        | [<CompiledName("is-flex-direction-column")>] Column
        /// <summary>Add <c>is-flex-direction-column-reverse</c></summary>
        | [<CompiledName("is-flex-direction-column-reverse")>] ColumnReverse

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexWrap =

    type Option =
        /// <summary>Add <c>is-flex-wrap-nowrap</c></summary>
        | [<CompiledName("is-flex-wrap-nowrap")>] NoWrap
        /// <summary>Add <c>is-flex-wrap-wrap</c></summary>
        | [<CompiledName("is-flex-wrap-wrap")>] Wrap
        /// <summary>Add <c>is-flex-wrap-wrap-reverse</c></summary>
        | [<CompiledName("is-flex-wrap-wrap-reverse")>] WrapReverse

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexJustifyContent =

    type Option =
        /// <summary>Add <c>is-justify-content-flex-start</c></summary>
        | [<CompiledName("is-justify-content-flex-start")>] FlexStart
        /// <summary>Add <c>is-justify-content-flex-end</c></summary>
        | [<CompiledName("is-justify-content-flex-end")>] FlexEnd
        /// <summary>Add <c>is-justify-content-center</c></summary>
        | [<CompiledName("is-justify-content-center")>] Center
        /// <summary>Add <c>is-justify-content-space-between</c></summary>
        | [<CompiledName("is-justify-content-space-between")>] SpaceBetween
        /// <summary>Add <c>is-justify-content-space-around</c></summary>
        | [<CompiledName("is-justify-content-space-around")>] SpaceAround
        /// <summary>Add <c>is-justify-content-space-evenly</c></summary>
        | [<CompiledName("is-justify-content-space-evenly")>] SpaceEvenly
        /// <summary>Add <c>is-justify-content-start</c></summary>
        | [<CompiledName("is-justify-content-start")>] Start
        /// <summary>Add <c>is-justify-content-end</c></summary>
        | [<CompiledName("is-justify-content-end")>] End
        /// <summary>Add <c>is-justify-content-left</c></summary>
        | [<CompiledName("is-justify-content-left")>] Left
        /// <summary>Add <c>is-justify-content-right</c></summary>
        | [<CompiledName("is-justify-content-right")>] Right

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexAlignContent =

    type Option =
        /// <summary>Add <c>is-align-content-flex-start</c></summary>
        | [<CompiledName("is-align-content-flex-start")>] FlexStart
        /// <summary>Add <c>is-align-content-flex-end</c></summary>
        | [<CompiledName("is-align-content-flex-end")>] FlexEnd
        /// <summary>Add <c>is-align-content-center</c></summary>
        | [<CompiledName("is-align-content-center")>] Center
        /// <summary>Add <c>is-align-content-space-between</c></summary>
        | [<CompiledName("is-align-content-space-between")>] SpaceBetween
        /// <summary>Add <c>is-align-content-space-around</c></summary>
        | [<CompiledName("is-align-content-space-around")>] SpaceAround
        /// <summary>Add <c>is-align-content-space-evenly</c></summary>
        | [<CompiledName("is-align-content-space-evenly")>] SpaceEvenly
        /// <summary>Add <c>is-align-content-stretch</c></summary>
        | [<CompiledName("is-align-content-stretch")>] Stretch
        /// <summary>Add <c>is-align-content-start</c></summary>
        | [<CompiledName("is-align-content-start")>] Start
        /// <summary>Add <c>is-align-content-end</c></summary>
        | [<CompiledName("is-align-content-end")>] End
        /// <summary>Add <c>is-align-content-baseline</c></summary>
        | [<CompiledName("is-align-content-baseline")>] Baseline

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt


[<RequireQualifiedAccess>]
module FlexAlignItems =

    type Option =
        /// <summary>Add <c>is-align-items-stretch</c></summary>
        | [<CompiledName("is-align-items-stretch")>] Stretch
        /// <summary>Add <c>is-align-items-flex-start</c></summary>
        | [<CompiledName("is-align-items-flex-start")>] FlexStart
        /// <summary>Add <c>is-align-items-flex-end</c></summary>
        | [<CompiledName("is-align-items-flex-end")>] FlexEnd
        /// <summary>Add <c>is-align-items-center</c></summary>
        | [<CompiledName("is-align-items-center")>] Center
        /// <summary>Add <c>is-align-items-baseline</c></summary>
        | [<CompiledName("is-align-items-baseline")>] Baseline
        /// <summary>Add <c>is-align-items-start</c></summary>
        | [<CompiledName("is-align-items-start")>] Start
        /// <summary>Add <c>is-align-items-end</c></summary>
        | [<CompiledName("is-align-items-end")>] End
        /// <summary>Add <c>is-align-items-self-start</c></summary>
        | [<CompiledName("is-align-items-self-start")>] SelfStart
        /// <summary>Add <c>is-align-items-self-end</c></summary>
        | [<CompiledName("is-align-items-self-end")>] SelfEnd

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexAlignSelf =

    type Option =
        /// <summary>Add <c>is-align-self-auto</c></summary>
        | [<CompiledName("is-align-self-auto")>] Auto
        /// <summary>Add <c>is-align-self-flex-start</c></summary>
        | [<CompiledName("is-align-self-flex-start")>] FlexStart
        /// <summary>Add <c>is-align-self-flex-end</c></summary>
        | [<CompiledName("is-align-self-flex-end")>] FlexEnd
        /// <summary>Add <c>is-align-self-center</c></summary>
        | [<CompiledName("is-align-self-center")>] Center
        /// <summary>Add <c>is-align-self-baseline</c></summary>
        | [<CompiledName("is-align-self-baseline")>] Baseline
        /// <summary>Add <c>is-align-self-stretch</c></summary>
        | [<CompiledName("is-align-self-stretch")>] Stretch

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexGrow =

    type Option =
        /// <summary>Add <c>is-flex-grow-0</c></summary>
        | [<CompiledName("is-flex-grow-0")>] Is0
        /// <summary>Add <c>is-flex-grow-1</c></summary>
        | [<CompiledName("is-flex-grow-1")>] Is1
        /// <summary>Add <c>is-flex-grow-2</c></summary>
        | [<CompiledName("is-flex-grow-2")>] Is2
        /// <summary>Add <c>is-flex-grow-3</c></summary>
        | [<CompiledName("is-flex-grow-3")>] Is3
        /// <summary>Add <c>is-flex-grow-4</c></summary>
        | [<CompiledName("is-flex-grow-4")>] Is4
        /// <summary>Add <c>is-flex-grow-5</c></summary>
        | [<CompiledName("is-flex-grow-5")>] Is5

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module FlexShrink =

    type Option =
        /// <summary>Add <c>is-flex-shrink-0</c></summary>
        | [<CompiledName("is-flex-shrink-0")>] Is0
        /// <summary>Add <c>is-flex-shrink-1</c></summary>
        | [<CompiledName("is-flex-shrink-1")>] Is1
        /// <summary>Add <c>is-flex-shrink-2</c></summary>
        | [<CompiledName("is-flex-shrink-2")>] Is2
        /// <summary>Add <c>is-flex-shrink-3</c></summary>
        | [<CompiledName("is-flex-shrink-3")>] Is3
        /// <summary>Add <c>is-flex-shrink-4</c></summary>
        | [<CompiledName("is-flex-shrink-4")>] Is4
        /// <summary>Add <c>is-flex-shrink-5</c></summary>
        | [<CompiledName("is-flex-shrink-5")>] Is5

        static member inline toClass (opt : Option) =
            Reflection.getCaseName opt


[<RequireQualifiedAccess>]
module TextWeight =

    type Option =
        /// Add `has-text-weight-light`
        | [<CompiledName("has-text-weight-light")>] Light
        /// Add `has-text-weight-normal`
        | [<CompiledName("has-text-weight-normal")>] Normal
        /// Add `has-text-weight-semibold`
        | [<CompiledName("has-text-weight-semibold")>] SemiBold
        /// Add `has-text-weight-bold`
        | [<CompiledName("has-text-weight-bold")>] Bold
        /// Add `has-text-weight-medium`
        | [<CompiledName("has-text-weight-medium")>] Medium

    let inline internal ofOption opt =
        Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module TextTransform =

    type Option =
        /// Add `is-capitalized`
        | [<CompiledName("is-capitalized")>] Capitalized
        /// Add `is-lowercase`
        | [<CompiledName("is-lowercase")>] LowerCase
        /// Add `is-uppercase`
        | [<CompiledName("is-uppercase")>] UpperCase
        /// Add `is-italic`
        | [<CompiledName("is-italic")>] Italic
        /// Add `is-underlined`
        | [<CompiledName("is-underlined")>] Underlined

        static member inline toClass opt =
            Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module Display =

    type Option =
        | [<CompiledName("block")>] Block
        | [<CompiledName("flex")>] Flex
        | [<CompiledName("inline")>] Inline
        | [<CompiledName("inline-block")>] InlineBlock
        | [<CompiledName("inline-flex")>] InlineFlex

        static member inline toClass opt =
            Reflection.getCaseName opt

    let internal toDisplayClass screen display =
        let display = Option.toClass display
        let screen = Screen.ToString screen

        "is-" + display + screen

    let internal toDisplayOnlyClass screen display =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            let display = Option.toClass display
            let screen = Screen.ToString screen
            "is-" + display + screen + "-only"

        | x ->
            Fable.Core.JS.console.warn(sprintf "Screen `%s` does not support display only." (string x))
            ""

[<RequireQualifiedAccess>]
module Spacing =
    type TypeAndDirection =
        | [<CompiledName("m")>] Margin
        | [<CompiledName("mt")>] MarginTop
        | [<CompiledName("mr")>] MarginRight
        | [<CompiledName("mb")>] MarginBottom
        | [<CompiledName("ml")>] MarginLeft
        | [<CompiledName("my")>] MarginTopAndBottom
        | [<CompiledName("mx")>] MarginLeftAndRight
        | [<CompiledName("p")>] Padding
        | [<CompiledName("pt")>] PaddingTop
        | [<CompiledName("pr")>] PaddingRight
        | [<CompiledName("pb")>] PaddingBottom
        | [<CompiledName("pl")>] PaddingLeft
        | [<CompiledName("py")>] PaddingTopAndBottom
        | [<CompiledName("px")>] PaddingLeftAndRight

        static member inline toClass opt =
            Reflection.getCaseName opt

    type Amount =
        | [<CompiledName("auto")>] IsAuto
        | [<CompiledName("0")>] Is0
        | [<CompiledName("1")>] Is1
        | [<CompiledName("2")>] Is2
        | [<CompiledName("3")>] Is3
        | [<CompiledName("4")>] Is4
        | [<CompiledName("5")>] Is5
        | [<CompiledName("6")>] Is6

        static member inline toClass opt =
            Reflection.getCaseName opt

    let internal toSpacingClass typ amount =
        let typ = TypeAndDirection.toClass typ
        let amount = Amount.toClass amount

        typ + "-" + amount

[<RequireQualifiedAccess>]
module Modifier =
    let internal ofBackground level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "has-background-" + color
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
        | IsWhiteBis -> "has-background-" + (Reflection.getCaseName level).[3..]

    let internal ofText level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "has-text-" + color
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
        | IsWhiteBis -> "has-text-" + (Reflection.getCaseName level).[3..]

    let internal ofInvisible screen =
        "is-invisible" + Screen.ToString screen

    let internal ofHidden screen =
        "is-hidden" + Screen.ToString screen

    let internal ofInvisibleOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-invisible" + Screen.ToString screen + "-only"
        | x ->
            Fable.Core.JS.console.warn(sprintf "Screen `%s` does not support `is-invisible-xxx-only`." (string x))
            ""

    let internal ofHiddenOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-hidden" + Screen.ToString screen + "-only"
        | x ->
            Fable.Core.JS.console.warn(sprintf "Screen `%s` does not support `is-hidden-xxx-only`." (string x))
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
        | [<CompiledName("is-clearfix")>] IsClearfix
        | [<CompiledName("is-pulled-left")>] IsPulledLeft
        | [<CompiledName("is-pulled-right")>] IsPulledRight
        | [<CompiledName("is-marginless")>] IsMarginless
        | [<CompiledName("is-paddingless")>] IsPaddingless
        | [<CompiledName("is-overlay")>] IsOverlay
        | [<CompiledName("is-clipped")>] IsClipped
        | [<CompiledName("is-radiusless")>] IsRadiusless
        | [<CompiledName("is-shadowless")>] IsShadowless
        | [<CompiledName("is-unselectable")>] IsUnselectable
        | [<CompiledName("is-clickable")>] IsClickable
        | [<CompiledName("is-relative")>] IsRelative
        | [<CompiledName("is-flex")>] IsFlex
        | IsInvisible of Screen * bool
        | IsHidden of Screen * bool
        | IsInvisibleOnly of Screen * bool
        | IsHiddenOnly of Screen * bool
        | IsSrOnly
        | IsScreenReaderOnly
        | Spacing of Spacing.TypeAndDirection * Spacing.Amount
        // Flexbox helpers
        | FlexDirection of FlexDirection.Option
        | FlexWrap of FlexWrap.Option
        | FlexJustifyContent of FlexJustifyContent.Option
        | FlexAlignContent of FlexAlignContent.Option
        | FlexAlignItems of FlexAlignItems.Option
        | FlexAlignSelf of FlexAlignSelf.Option
        | FlexGrow of FlexGrow.Option
        | FlexShrink of FlexShrink.Option



                //     | IsGap (screen, size) ->
                // if not (List.contains "is-variable" result.Classes) then
                //     result.AddClass("is-variable").AddClass(gapSizeGeneric screen size)
                // else
                //     result.AddClass(gapSizeGeneric screen size)



    let parseModifiers options =
        let parseOptions result option =
            match option with
            | BackgroundColor color             -> (ofBackground color)::result
            | TextColor color                   -> (ofText color)::result
            | TextWeight textWeight             -> (TextWeight.ofOption textWeight)::result
            | TextSize (screen, size)           -> (TextSize.generic screen size)::result
            | TextSizeOnly (screen, size)       -> (TextSize.only screen size)::result
            | TextAlignment (screen, size)      -> (TextAlignment.generic screen size)::result
            | TextAlignmentOnly (screen, size)  -> (TextAlignment.only screen size)::result
            | TextTransform transform           -> (TextTransform.Option.toClass transform)::result
            | Display (screen, display)         -> (Display.toDisplayClass screen display)::result
            | DisplayOnly (screen, display)     -> (Display.toDisplayOnlyClass screen display)::result
            | IsInvisible (screen, b)           -> if b then (ofInvisible screen)::result else result
            | IsInvisibleOnly (screen, b)       -> if b then (ofInvisibleOnly screen)::result else result
            | IsHidden (screen, b)              -> if b then (ofHidden screen)::result else result
            | IsHiddenOnly (screen, b)          -> if b then (ofHiddenOnly screen)::result else result
            | IsSrOnly
            | IsScreenReaderOnly -> "is-sr-only"::result
            | IsClearfix
            | IsPulledLeft
            | IsPulledRight
            | IsMarginless
            | IsPaddingless
            | IsOverlay
            | IsClipped
            | IsRadiusless
            | IsShadowless
            | IsClickable
            | IsUnselectable
            | IsFlex
            | IsRelative -> (Reflection.getCaseName option)::result
            | Spacing (typ, amount) -> (Spacing.toSpacingClass typ amount)::result
            | FlexDirection direction ->
                if not (List.contains "is-flex" result) then
                    "is-flex"::(FlexDirection.Option.toClass direction)::result
                else
                    (FlexDirection.Option.toClass direction)::result
            | FlexWrap option ->
                if not (List.contains "is-flex" result) then
                    "is-flex"::(FlexWrap.Option.toClass option)::result
                else
                    (FlexWrap.Option.toClass option)::result
            | FlexJustifyContent option ->
                if not (List.contains "is-flex" result) then
                    "is-flex"::(FlexJustifyContent.Option.toClass option)::result
                else
                    (FlexJustifyContent.Option.toClass option)::result
            | FlexAlignContent option ->
                if not (List.contains "is-flex" result) then
                    "is-flex"::(FlexAlignContent.Option.toClass option)::result
                else
                    (FlexAlignContent.Option.toClass option)::result
            | FlexAlignItems option ->
                if not (List.contains "is-flex" result) then
                    "is-flex"::(FlexAlignItems.Option.toClass option)::result
                else
                    (FlexAlignItems.Option.toClass option)::result

            | FlexAlignSelf option ->
                (FlexAlignSelf.Option.toClass option)::result

            | FlexGrow size ->
                (FlexGrow.Option.toClass size)::result

            | FlexShrink size ->
                (FlexShrink.Option.toClass size)::result

        options |> List.fold parseOptions []

[<AutoOpen>]
module Common =
    type GenericOption =
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type GenericOptions =
        { Props : IHTMLProp list
          Classes : string list
          RemovedClasses : string list }

        static member Empty =
            { Props = []; Classes = []; RemovedClasses = [] }

        static member Parse(options, parser, ?baseClass, ?baseProps) =
            let result = options |> List.fold parser GenericOptions.Empty

            let result =
                match baseClass with
                | Some baseClass -> result.AddClass(baseClass)
                | None -> result

            match baseProps with
            | Some baseProps -> result.AddProps(baseProps)
            | None -> result

        member this.AddProp(prop : IHTMLProp) =
            { this with Props = prop::this.Props }

        member this.AddProps(props : IHTMLProp list) =
            { this with Props = props@this.Props }

        member this.AddClass(cl: string) =
            { this with Classes = cl::this.Classes }

        member this.RemoveClass(cl: string) =
            { this with RemovedClasses = cl::this.RemovedClasses }

        member this.AddCaseName(case: 'T) =
            Reflection.getCaseName case |> this.AddClass

        member this.AddModifiers(modifiers) =
            { this with Classes = (modifiers |> Modifier.parseModifiers) @ this.Classes }

        member this.ToAttributes() =
            match this.Classes |> List.filter (fun cls -> not (System.String.IsNullOrEmpty cls) && not (List.contains cls this.RemovedClasses)) with
            | [] -> this.Props
            | classes -> (classes |> String.concat " " |> ClassName :> _) :: this.Props

        /// Convert to standard element
        member this.ToReactElement(el : IHTMLProp list -> ReactElement list -> ReactElement, ?children): ReactElement =
            let children = defaultArg children []
            el (this.ToAttributes ()) children

        /// Convert to self closing element
        member this.ToReactElement(el : IHTMLProp list -> ReactElement): ReactElement =
            el (this.ToAttributes ())

    let parseOptions (result : GenericOptions) option =
        match option with
        | Props props -> result.AddProps props
        | CustomClass customClass -> result.AddClass customClass
        | Modifiers modifiers -> result.AddModifiers modifiers

    module Helpers =

        [<System.Obsolete("Use GenericOptions.Parse. This build an abstraction layer usable by all the components and helps reduce the bundle size")>]
        let classes std (options : string option list) (booleans: (string * bool) list) =
            let std = (std, options) ||> List.fold (fun complete option ->
                match option with
                | Some name -> complete + " " + name
                | None -> complete )
            (std, booleans) ||> List.fold (fun complete (name, flag) ->
                if flag then complete + " " + name else complete)
            |> ClassName :> IHTMLProp

[<RequireQualifiedAccess>]
module Text =
    open Fable.React

    let p (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions).ToReactElement(p, children)

    let div (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions).ToReactElement(div, children)

    let span (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions).ToReactElement(span, children)
