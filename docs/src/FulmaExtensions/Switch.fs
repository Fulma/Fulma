module FulmaExtensions.Switch

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Layouts
open Fulma.Extensions
open Fulma.Extra.FontAwesome

let inlineBlockInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                [ b [] [str "Block"]
                  Switch.switch [ ] [ str "One" ]
                  Switch.switch [ ] [ str "Two" ]

                  b [] [str "Inline"]
                  Field.div [ ]
                      [ yield! Switch.switchInline [ ] [ str "One" ]
                        yield! Switch.switchInline [ ] [ str "Two" ] ] ] ] ]

let rtl () =
    Switch.switch [ Switch.IsRtl ] [ str "Label is on the left" ]


let colorInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true ] [ str "Default" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsWhite ] [ str "White" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsLight ] [ str "Light" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsDark ] [ str "Dark" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsBlack ] [ str "Black" ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true; Switch.Color IsPrimary ] [ str "Primary" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsInfo ] [ str "Info" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsSuccess ] [ str "Success" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsWarning ] [ str "Warning" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsDanger ] [ str "Danger" ] ] ] ]


let sizeInteractive () =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Checked true; Switch.Size IsSmall ] [ str "Small" ]
          Switch.switch [ Switch.Checked true ] [ str "Normal" ]
          Switch.switch [ Switch.Checked true; Switch.Size IsMedium ] [ str "Medium" ]
          Switch.switch [ Switch.Checked true; Switch.Size IsLarge ] [ str "Large" ] ]


let stylesInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ] ]


let stateInteractive () =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Disabled true ] [ str "Disabled" ]
          Switch.switch [ Switch.Disabled true; Switch.Checked true ] [ str "Disabled & Checked" ]
          Switch.switch [ ] [ str "Unchecked" ]
          Switch.switch [ Switch.Checked true ] [ str "checked" ] ]

[<Pojo>]
type SwitchDemoProps =
    interface end

[<Pojo>]
type SwitchDemoState =
    { IsChecked : bool }

type SwitchDemo(props) =
    inherit React.Component<SwitchDemoProps, SwitchDemoState>(props)
    do base.setInitState({ IsChecked = false })

    member this.toggleState _ =
        { this.state with IsChecked = not this.state.IsChecked}
        |> this.setState

    override this.render () =
        div [ ClassName "block" ]
            [ Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.OnChange this.toggleState ]
                [ str (string this.state.IsChecked) ]
              Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.OnChange this.toggleState ]
                [ if this.state.IsChecked then
                    yield Icon.faIcon [ ] [ Fa.icon Fa.I.Check ]
                  else
                    yield Icon.faIcon [ ] [ Fa.icon Fa.I.Times ] ] ]

let demoView () =
    // Fake values, and helpers
    let isChecked = true
    let toggleState _ = ()
    // View part
    div [ ClassName "block" ]
        [ Switch.switch
            [ Switch.Checked isChecked
              Switch.OnChange toggleState ]
            [ str (string isChecked) ]
          Switch.switch
            [ Switch.Checked isChecked
              Switch.OnChange toggleState ]
            [ if isChecked then
                yield Icon.faIcon [ ] [ Fa.icon Fa.I.Check ]
              else
                yield Icon.faIcon [ ] [ Fa.icon Fa.I.Times ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Switch

The **Switch** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/form/switch/)*

## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-switch`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-switch@0.0.4`</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        "### Inline vs Block"
                        (Widgets.Showcase.view inlineBlockInteractive (Render.getViewSource inlineBlockInteractive))
                     Render.docSection
                        "### Text position"
                        (Widgets.Showcase.view rtl (Render.getViewSource rtl))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.getViewSource colorInteractive))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.getViewSource sizeInteractive))
                     Render.docSection
                        """
### Styles
The switch can be **rounded, outlined, thin or any combinaison of those**.
                        """
                        (Widgets.Showcase.view stylesInteractive (Render.getViewSource stylesInteractive))
                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.getViewSource stateInteractive))
                     Render.docSection
                        "### Event handler"
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchDemo,_,_> (unbox null) []) (Render.getViewSource demoView)) ]
