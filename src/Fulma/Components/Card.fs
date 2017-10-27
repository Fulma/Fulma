namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Card =

    let customClass = CustomClass
    let props = Props

    let card (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Card.Container [opts.CustomClass] []
        div (class'::opts.Props) children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Card.Header.Container [opts.CustomClass] []
        header (class'::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Card.Content [opts.CustomClass] []
        div (class'::opts.Props) children

    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Card.Footer.Container [opts.CustomClass] []
        footer (class'::opts.Props) children

    module Header =

        let customClass = CustomClass
        let props = Props

        let icon (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Card.Header.Icon [opts.CustomClass] []
            a (class'::opts.Props) children

        let title (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Card.Header.Title [opts.CustomClass] []
            p (class'::opts.Props) children

    module Footer =

        let customClass = CustomClass
        let props = Props

        let item (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Card.Footer.Item [opts.CustomClass] []
            a (class'::opts.Props) children
