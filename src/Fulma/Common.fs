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

        module TextColor =
            let [<Literal>] Black = "has-text-black"

    let ofBackground level =
        match level with
        | IsBlack -> Classes.BackgroundColor.Black

    let ofText level =
        match level with
        | IsBlack -> Classes.BackgroundColor.Black

    type IModifier =
        | HasBackgroundColor of IColor
        | HasTextColor of IColor

    type internal Options =
        { BackgroundColor : string option
          TextColor : string option }

        static member Empty =
            { BackgroundColor = None
              TextColor = None }

    let parseOptions options =
        let parseOption result opt =
            match opt with
            | HasBackgroundColor color -> { result with BackgroundColor = color |> ofBackground |> Some }
            | HasTextColor color -> { result with TextColor = color |> ofText |> Some }

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
