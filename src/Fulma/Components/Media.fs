namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Media =

    let media (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Media.Container [opts.CustomClass] []
        article (class'::opts.Props) children

    let left (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Media.Left [opts.CustomClass] []
        figure (class'::opts.Props) children

    let right (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Media.Right [opts.CustomClass] []
        div (class'::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Media.Content [opts.CustomClass] []
        div (class'::opts.Props) children
