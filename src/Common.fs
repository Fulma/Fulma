namespace Elmish.Bulma

open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Helpers.React.Props

module Common =
    type ISize =
        | IsSmall
        | IsMedium
        | IsLarge

    type ILevelAndColor =
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger

    let ofLevelAndColor level =
        match level with
        | IsBlack -> Bulma.Modifiers.Color.IsBlack
        | IsDark -> Bulma.Modifiers.Color.IsDark
        | IsLight -> Bulma.Modifiers.Color.IsLight
        | IsWhite -> Bulma.Modifiers.Color.IsWhite
        | IsPrimary -> Bulma.Modifiers.Color.IsPrimary
        | IsInfo -> Bulma.Modifiers.Color.IsInfo
        | IsSuccess -> Bulma.Modifiers.Color.IsSuccess
        | IsWarning -> Bulma.Modifiers.Color.IsWarning
        | IsDanger -> Bulma.Modifiers.Color.IsDanger

    let ofSize size =
        match size with
        | IsSmall -> Bulma.Modifiers.Size.IsSmall
        | IsMedium -> Bulma.Modifiers.Size.IsMedium
        | IsLarge -> Bulma.Modifiers.Size.IsLarge

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
        let inline generateClassName baseClass (values : string option list) =
            baseClass :: (values
                          |> List.filter (fun x -> x.IsSome)
                          |> List.map (fun x -> x.Value))
            |> String.concat " "
