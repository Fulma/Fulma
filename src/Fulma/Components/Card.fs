namespace Fulma.Components

open Fulma
open Fable.Helpers.React

[<RequireQualifiedAccess>]
module Card =

    module Classes =
        let [<Literal>] Container = "card"
        module Header =
            let [<Literal>] Container = "card-header"
            let [<Literal>] Title = "card-header-title"
            let [<Literal>] Icon ="card-header-icon"
        let [<Literal>] Image = "card-image"
        let [<Literal>] Content = "card-content"
        module Footer =
            let [<Literal>] Container = "card-footer"
            let [<Literal>] Item = "card-footer-item"

    let card (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        div (classes::opts.Props) children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Header.Container [opts.CustomClass] []
        header (classes::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content [opts.CustomClass] []
        div (classes::opts.Props) children

    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Footer.Container [opts.CustomClass] []
        footer (classes::opts.Props) children

    module Header =

        let icon (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Header.Icon [opts.CustomClass] []
            a (classes::opts.Props) children

        let title (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Header.Title [opts.CustomClass] []
            p (classes::opts.Props) children

    module Footer =

        let item (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Footer.Item [opts.CustomClass] []
            a (classes::opts.Props) children
