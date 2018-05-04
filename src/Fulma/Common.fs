namespace Fulma

open Fable.Core
open Fable.Helpers.React.Props

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

[<AutoOpen>]
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

    let ofBackground level =
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

    let ofText level =
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

    type IModifier =
        | BackgroundColor of IColor
        | TextColor of IColor

    type internal Options =
        { BackgroundColor : string option
          TextColor : string option }

        static member Empty =
            { BackgroundColor = None
              TextColor = None }

    let parseOptions options =
        let parseOption result opt =
            match opt with
            | BackgroundColor color -> { result with BackgroundColor = color |> ofBackground |> Some }
            | TextColor color -> { result with TextColor = color |> ofText |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        [opts.BackgroundColor; opts.TextColor]

[<AutoOpen>]
module Common =
    type GenericOption =
        | CustomClass of string
        | Props of IHTMLProp list

    type GenericOptions =
        { CustomClass : string option
          Props : IHTMLProp list }

        static member Empty =
            { CustomClass = None
              Props = [] }

    let genericParse options =
        let parseOptions (result: GenericOptions ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        options |> List.fold parseOptions GenericOptions.Empty

    module Helpers =

        let classes std (options : string option list) (booleans: (string * bool) list) =
            let std = (std, options) ||> List.fold (fun complete opt ->
                match opt with Some name -> complete + " " + name | None -> complete)
            (std, booleans) ||> List.fold (fun complete (name, flag) ->
                if flag then complete + " " + name else complete)
            |> ClassName :> IHTMLProp

    [<Pojo>]
    type DangerousInnerHtml =
        { __html : string }
