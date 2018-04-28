namespace Fulma

open Fable.Core
open Fable.Helpers.React.Props

[<AutoOpen>]
module Color =

    module Classes =
        let [<Literal>] IsBlack = "has-background-black"
        let [<Literal>] IsDark = "has-background-dark"
        let [<Literal>] IsLight = "has-background-light"
        let [<Literal>] IsWhite = "has-background-white"
        let [<Literal>] IsPrimary = "has-background-primary"
        let [<Literal>] IsInfo = "has-background-info"
        let [<Literal>] IsSuccess = "has-background-success"
        let [<Literal>] IsWarning = "has-background-warning"
        let [<Literal>] IsDanger = "has-background-danger"
        let [<Literal>] IsLink = "has-background-link"
        let [<Literal>] IsBlackBis = "has-background-black-bis"
        let [<Literal>] IsBlackTer = "has-background-black-ter"
        let [<Literal>] IsGreyDarker = "has-background-grey-darker"
        let [<Literal>] IsGreyDark = "has-background-grey-dark"
        let [<Literal>] IsGrey = "has-background-grey"
        let [<Literal>] IsGreyLight = "has-background-grey-light"
        let [<Literal>] IsGreyLighter = "has-background-grey-lighter"
        let [<Literal>] IsWhiteTer = "has-background-white-ter"
        let [<Literal>] IsWhiteBis = "has-background-white-bis"

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
