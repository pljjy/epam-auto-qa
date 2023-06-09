using OpenQA.Selenium;

namespace Epam.TestCases.Epam.Site;

/// <summary>
/// Locators for EmailSend TestFixture
/// 
/// Some locators are unnecessary and I can't test them properly
/// since the information is only sent to server
/// </summary>
public static class EmailSendLocators
{
    public static readonly By firstName =
        By.XPath(
            "//input[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_first_name']");

    public static readonly By lastName =
        By.XPath(
            "//input[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_last_name']");

    public static readonly By emailInput =
        By.XPath(
            "//input[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_email']");

    public static readonly By phoneInput =
        By.XPath(
            "//input[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_phone']");

    public static readonly By locationSpan =
            By.XPath(
                "//span[@aria-labelledby='select2-_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_country-container']");

    public static readonly By hearAboutEpamSpan = By.XPath(
        "//span[@aria-labelledby='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_comment_how_hear_about-label select2-_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_comment_how_hear_about-container']");

    public static readonly By consentCheckBox = By.XPath("//input[@name='gdprConsent'][@type='checkbox']");

    #region Unnecesary inputs

    public static readonly By messageInput =
        By.XPath(
            "//textarea[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_comment']");

    public static readonly By companyInput =
        By.XPath(
            "//input[@id='_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_company']");

    public static readonly By positionInput =
        By.XPath(
            "//input[@aria-owns='select2-_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_position-results']");

    public static readonly By cityInput =
        By.XPath(
            "//span[@aria-labelledby='select2-_content_epam_en_about_who-we-are_contact_jcr_content_content-container_section_section-par_form_constructor_user_country-container']");
    //public static readonly By

    #endregion


    //public static readonly By
}