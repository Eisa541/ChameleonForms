﻿using System;
using System.Linq.Expressions;
using ChameleonForms.Component;
using ChameleonForms.Component.Config;
using ChameleonForms.Templates;

namespace ChameleonForms.FieldGenerators
{
    /// <summary>
    /// Generates the HTML for a single form field.
    /// </summary>
    public interface IFieldGenerator<TModel, T> : IFieldGenerator
    {
        /// <summary>
        /// The view and its model.
        /// </summary>
        IViewWithModel<TModel> View { get; }

        /// <summary>
        /// The expression that identifies the property in the model being output.
        /// </summary>
        Expression<Func<TModel, T>> FieldProperty { get; }

        /// <summary>
        /// Returns the current value of the field.
        /// </summary>
        /// <returns>The current field value</returns>
        T GetValue();

        /// <summary>
        /// Returns a model with the current values for the form.
        /// </summary>
        /// <returns>The current model</returns>
        TModel GetModel();

        /// <summary>
        /// Returns the displayable name of the field being generated.
        /// </summary>
        /// <returns>The id</returns>
        string GetFieldDisplayName();
    }

    /// <summary>
    /// Generates the HTML for a single form field.
    /// </summary>
    public interface IFieldGenerator
    {
        /// <summary>
        /// The metadata for the form field.
        /// </summary>
        IFieldMetadata Metadata { get; }

        /// <summary>
        /// The form template that will be used to render the form.
        /// </summary>
        IFormTemplate Template { get; }

        /// <summary>
        /// Turns the given <see cref="IFieldConfiguration"/> into a <see cref="FieldConfiguration"/> ready to use for generating the form field.
        /// </summary>
        /// <param name="fieldConfiguration">The field configuration to modify</param>
        /// <param name="fieldParent">The parent component of the field</param>
        /// <returns>The readonly field configuration; ready for generating the form field</returns>
        IReadonlyFieldConfiguration PrepareFieldConfiguration(IFieldConfiguration fieldConfiguration, FieldParent fieldParent);

        /// <summary>
        /// Creates the HTML for the field control.
        /// </summary>
        /// <returns>The HTML for the field control</returns>
        IHtml GetFieldHtml(IReadonlyFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Creates the HTML for the field label.
        /// </summary>
        /// <returns>The HTML for the field label</returns>
        IHtml GetLabelHtml(IReadonlyFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Creates the HTML for the field's validation messages
        /// </summary>
        /// <returns>The HTML for the field's validation messages</returns>
        IHtml GetValidationHtml(IReadonlyFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Creates the HTML for the field control after preparing the given field configuration.
        /// </summary>
        /// <returns>The HTML for the field control</returns>
        IHtml GetFieldHtml(IFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Creates the HTML for the field label after preparing the given field configuration.
        /// </summary>
        /// <returns>The HTML for the field label</returns>
        IHtml GetLabelHtml(IFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Creates the HTML for the field's validation messages after preparing the given field configuration.
        /// </summary>
        /// <returns>The HTML for the field's validation messages</returns>
        IHtml GetValidationHtml(IFieldConfiguration fieldConfiguration);

        /// <summary>
        /// Returns the id of the field being generated.
        /// </summary>
        /// <returns>The id</returns>
        string GetFieldId();
    }
}
