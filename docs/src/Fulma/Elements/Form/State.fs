module Elements.Form.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    form [ ]
         [ Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Name" ]
                  Control.control_div [ ]
                    [ Input.input [ Input.typeIsText
                                    Input.placeholder "Ex: Maxime" ] ] ]
           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Username" ]
                  Control.control_div [ Control.hasIconLeft
                                        Control.hasIconRight ]
                    [ Input.text [ Input.isSuccess
                                   Input.defaultValue "Maxime" ]
                      Icon.faIcon [ Icon.isSmall; Icon.isLeft ] Fa.User
                      Icon.faIcon [ Icon.isSmall; Icon.isRight ] Fa.Check ]
                  Help.help [ Help.isSuccess ]
                    [ str "This username is available" ] ]

           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Email" ]
                  Control.control_div [ Control.hasIconLeft
                                        Control.hasIconRight ]
                    [ Input.email [ Input.isDanger
                                    Input.defaultValue "hello@" ]
                      Icon.faIcon [ Icon.isSmall; Icon.isLeft ] Fa.Envelope
                      Icon.faIcon [ Icon.isSmall; Icon.isRight ] Fa.Warning ]
                  Help.help [ Help.isDanger ]
                    [ str "This email is invalid" ] ]

           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Subject" ]
                  Control.control_div [ ]
                    [ Select.select [ ]
                        [ select [ DefaultValue "2" ]
                            [ option [ Value "1" ] [ str "Value n°1" ]
                              option [ Value "2"] [ str "Value n°2" ]
                              option [ Value "3"] [ str "Value n°3" ] ] ] ] ]
           Field.field_div [ ]
                [ Label.label [ ]
                    [ str "Message" ]
                  Control.control_div [ Control.isLoading ]
                    [ Textarea.textarea [ ]
                        [ ] ] ]

           Field.field_div [ ]
                [ Control.control_div [ ]
                    [ Checkbox.checkbox [ ]
                        [ Checkbox.input [ ]
                          str "I agree with the terms and conditions" ] ] ]

           Field.field_div [ ]
                [ Control.control_div [ ]
                    [ Radio.radio [ ]
                        [ Radio.input [ Radio.Input.name "answer" ]
                          str "Yes" ]
                      Radio.radio [ ]
                        [ Radio.input [ Radio.Input.name "answer" ]
                          str "No" ] ] ]

           Field.field_div [ Field.isGrouped ]
                [ Control.control_div [ ]
                    [ Button.button [ Button.isPrimary ]
                        [ str "Submit" ] ]
                  Control.control_div [ ]
                    [ Button.button [ Button.isLink ]
                        [ str "Cancel" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Form

All generic **form controls**, designed for consistency

*[Bulma documentation](http://bulma.io/documentation/form/general/)*
        """
      BoxViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg
