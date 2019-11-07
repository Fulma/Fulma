module Fulma.Versions

let view =
    Render.contentFromMarkdown
        """
<center style="width: 200px;margin: auto;">
    ![Fulma logo](assets/logo_transparent.svg)
</center>

Here you can find which version of each library is supported by Fulma.

<table class="table is-striped is-hoverable is-bordered" style="width: auto;">
    <thead>
        <tr>
            <th style="min-width: 12rem; text-align: center;">Fulma</th>
            <th style="min-width: 12rem; text-align: center;">Bulma</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>2.4.0</td>
            <td>0.8.0</td>
        </tr>
        <tr>
            <td>2.3.0</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.2.1</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.2.0</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.1.1</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.1.0</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.0.1</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.0.0</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.0.0-beta-003</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.0.0-beta-002</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>2.0.0-beta-001</td>
            <td>0.7.2</td>
        </tr>
        <tr>
            <td>1.1.0</td>
            <td>0.7.2</td>
        </tr>
    </tbody>
<table>
        """
