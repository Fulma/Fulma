module Elements.Form

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

let basic () =
    form [ ]
         [ // Name field
           Field.div [ ]
                [ Label.label [ ]
                    [ str "Name" ]
                  Control.div [ ]
                    [ Input.text [ Input.Placeholder "Ex: Maxime" ] ] ]
           // Username field
           Field.div [ ]
                [ Label.label [ ]
                    [ str "Username" ]
                  Control.div [ Control.HasIconLeft
                                Control.HasIconRight ]
                    [ Input.text [ Input.Color IsSuccess
                                   Input.DefaultValue "Maxime" ]
                      Icon.faIcon [ Icon.Size IsSmall; Icon.IsLeft ] [ Fa.icon Fa.I.User ]
                      Icon.faIcon [ Icon.Size IsSmall; Icon.IsRight ] [ Fa.icon Fa.I.Check ] ]
                  Help.help [ Help.Color IsSuccess ]
                    [ str "This username is available" ] ]
           // Email field
           Field.div [ ]
                [ Label.label [ ]
                    [ str "Email" ]
                  Control.div [ Control.HasIconLeft
                                Control.HasIconRight ]
                    [ Input.email [ Input.Color IsDanger
                                    Input.DefaultValue "hello@" ]
                      Icon.faIcon [ Icon.Size IsSmall; Icon.IsLeft ] [ Fa.icon Fa.I.Envelope ]
                      Icon.faIcon [ Icon.Size IsSmall; Icon.IsRight ] [ Fa.icon Fa.I.Warning ] ]
                  Help.help [ Help.Color IsDanger ]
                    [ str "This email is invalid" ] ]
           // Phone field
           Field.div [ ]
                [ Field.div [ Field.HasAddons ]
                    [ Control.p [ ]
                        [ Button.button [ Button.IsStatic true ]
                            [ str "+32" ] ]
                      Control.p [ Control.IsExpanded ]
                        [ Input.tel [ Input.Placeholder "expanded phone number field" ] ] ] ]
            // Subject field
           Field.div [ ]
                [ Label.label [ ]
                    [ str "Subject" ]
                  Control.div [ ]
                    [ Select.select [ ]
                        [ select [ DefaultValue "2" ]
                            [ option [ Value "1" ] [ str "Value n°1" ]
                              option [ Value "2"] [ str "Value n°2" ]
                              option [ Value "3"] [ str "Value n°3" ] ] ] ] ]
           // Message field
           Field.div [ ]
                [ Label.label [ ]
                    [ str "Message" ]
                  Control.div [ Control.IsLoading true ]
                    [ Textarea.textarea [ ]
                        [ ] ] ]
           // Terms and conditions area
           Field.div [ ]
                [ Control.div [ ]
                    [ Checkbox.checkbox [ ]
                        [ Checkbox.input [ ]
                          str "I agree with the terms and conditions" ] ] ]
           // Validation fields
           Field.div [ ]
                [ Control.div [ ]
                    [ Radio.radio [ ]
                        [ Radio.input [ Radio.Input.Name "answer" ]
                          str "Yes" ]
                      Radio.radio [ ]
                        [ Radio.input [ Radio.Input.Name "answer" ]
                          str "No" ] ] ]
           // Attachment
           Field.div [ ]
                [ File.file [ File.HasName ]
                    [ File.label [ ]
                        [ File.input [ ]
                          File.cta [ ]
                            [ File.icon [ ]
                                [ Icon.faIcon [ ] [ Fa.icon Fa.I.Upload ] ]
                              File.label [ ]
                                [ str "Choose a file..." ] ]
                          File.name [ ]
                            [ str "License agreement.pdf" ] ] ] ]
           // Control area (submit, cancel, etc.)
           Field.div [ Field.IsGrouped ]
                [ Control.div [ ]
                    [ Button.button [ Button.Color IsPrimary ]
                        [ str "Submit" ] ]
                  Control.div [ ]
                    [ Button.button [ Button.IsLink ]
                        [ str "Cancel" ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Form

All generic **form controls**, designed for consistency

*[Bulma documentation](http://bulma.io/documentation/form/general/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic)) ]
