module FulmaExtensions.Switch

open Fable.Core
open Fable.Import
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Extensions.Wikiki
open Fable.FontAwesome

let inlineBlockInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                [ b [ ] [ str "Block" ]
                  Switch.switch [ Switch.Id "switch-1" ]
                    [ str "One" ]
                  Switch.switch [ Switch.Id "switch-2" ]
                    [ str "Two" ]
                  // ----------------
                  b [ ] [ str "Inline" ]
                  Field.div [ ]
                      [ Switch.switchInline [ Switch.Id "switch-3" ]
                            [ str "One" ]
                        Switch.switchInline [ Switch.Id "switch-4"
                                              Switch.LabelProps [ Style [ MarginLeft "2rem" ] ] ]
                            [ str "Two" ] ] ] ] ]

let rtl () =
    Switch.switch [ Switch.IsRtl
                    Switch.Id "switch-5" ]
        [ str "Label is on the left" ]

let colorInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-6" ]
                        [ str "Default" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-7"
                                    Switch.Color IsWhite ]
                        [ str "White" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-8"
                                    Switch.Color IsLight ]
                        [ str "Light" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-9"
                                    Switch.Color IsDark ]
                        [ str "Dark" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-10"
                                    Switch.Color IsBlack ]
                        [ str "Black" ] ] ]
          // ----------------
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-11"
                                    Switch.Color IsPrimary ]
                        [ str "Primary" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-12"
                                    Switch.Color IsInfo ]
                        [ str "Info" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-13"
                                    Switch.Color IsSuccess ]
                        [ str "Success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-14"
                                    Switch.Color IsWarning ]
                        [ str "Warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-15"
                                    Switch.Color IsDanger ]
                        [ str "Danger" ] ] ] ]


let sizeInteractive () =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Checked true
                          Switch.Id "switch-16"
                          Switch.Size IsSmall ]
            [ str "Small" ]
          Switch.switch [ Switch.Checked true
                          Switch.Id "switch-17" ]
            [ str "Normal" ]
          Switch.switch [ Switch.Checked true
                          Switch.Id "switch-18"
                          Switch.Size IsMedium ]
            [ str "Medium" ]
          Switch.switch [ Switch.Checked true
                          Switch.Id "switch-19"
                          Switch.Size IsLarge ]
            [ str "Large" ] ]


let stylesInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-20"
                                    Switch.IsRounded
                                    Switch.Disabled true ]
                        [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-21"
                                    Switch.IsRounded
                                    Switch.Color IsPrimary ]
                        [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-22"
                                    Switch.IsRounded
                                    Switch.Color IsSuccess ]
                        [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-23"
                                    Switch.IsRounded
                                    Switch.Color IsWarning ]
                        [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-24"
                                    Switch.IsRounded
                                    Switch.Color IsDanger ]
                        [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-25"
                                    Switch.IsRounded
                                    Switch.Color IsInfo ]
                        [ str "Checkbox - info" ] ] ]
          // ----------------
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-26"
                                    Switch.IsThin
                                    Switch.Disabled true ]
                        [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-27"
                                    Switch.IsThin
                                    Switch.Color IsPrimary ]
                        [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-28"
                                    Switch.IsThin
                                    Switch.Color IsSuccess ]
                        [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-29"
                                    Switch.IsThin
                                    Switch.Color IsWarning ]
                        [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-30"
                                    Switch.IsThin
                                    Switch.Color IsDanger ]
                        [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-31"
                                    Switch.IsThin
                                    Switch.Color IsInfo ]
                        [ str "Checkbox - info" ] ] ]
          // ----------------
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-32"
                                    Switch.IsOutlined
                                    Switch.Disabled true ]
                        [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-33"
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ]
                        [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-34"
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ]
                        [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-35"
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ]
                        [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-36"
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ]
                        [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-37"
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ]
                        [ str "Checkbox - info" ] ] ]
          // ----------------
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-38"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Disabled true ]
                        [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-39"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ]
                        [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-40"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ]
                        [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-41"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ]
                        [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-42"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ]
                        [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.Id "switch-43"
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ]
                        [ str "Checkbox - info" ] ] ] ]

let stateInteractive () =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Disabled true
                          Switch.Id "switch-44" ]
            [ str "Disabled" ]
          Switch.switch [ Switch.Disabled true
                          Switch.Checked true
                          Switch.Id "switch-45" ]
            [ str "Disabled & Checked" ]
          Switch.switch [ ]
            [ str "Unchecked" ]
          Switch.switch [ Switch.Checked true
                          Switch.Id "switch-46" ]
            [ str "checked" ] ]

type SwitchDemoProps =
    interface end

type SwitchDemoState =
    { IsChecked : bool }

type SwitchDemo(props) =
    inherit Component<SwitchDemoProps, SwitchDemoState>(props)
    do base.setInitState({ IsChecked = false })

    member this.toggleState _ =
        this.setState (fun prevState _ ->
            { prevState with IsChecked = not this.state.IsChecked}
        )

    override this.render () =
        div [ ClassName "block" ]
            [ Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.Id "switch-47"
                  Switch.OnChange this.toggleState ]
                [ str (string this.state.IsChecked) ]
              Switch.switch
                [ Switch.Checked this.state.IsChecked
                  Switch.Id "switch-48"
                  Switch.OnChange this.toggleState ]
                [ if this.state.IsChecked then
                    yield Icon.icon [ ]
                            [ Fa.i [ Fa.Solid.Check ]
                                [ ] ]
                  else
                    yield Icon.icon [ ]
                            [ Fa.i [ Fa.Solid.Times ]
                                [ ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Switch

The **Switch** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/form/switch/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Switch --project <your project>`
- `yarn add bulma-switch@2.0.0`

### Versions compatibility

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma.Extensions.Wikiki.Switch</th>
            <th>bulma-switch</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>2.0.0</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        """
<div class="message is-info">
    <div class="message-body">
        You need to provide <code>Switch.Id "unique-id"</code> in order to make <code>Switch</code> works
    </div>
</div>

### Inline vs Block
                        """
                        (Widgets.Showcase.view inlineBlockInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Text position"
                        (Widgets.Showcase.view rtl (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Styles
The switch can be **rounded, outlined, thin or any combinaison of those**.
                        """
                        (Widgets.Showcase.view stylesInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Event handler"
                        (Widgets.Showcase.view (fun _ -> ofType<SwitchDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
