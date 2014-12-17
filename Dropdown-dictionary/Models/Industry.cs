using System.ComponentModel.DataAnnotations;

namespace Dropdowns.Models
{
    public enum Industry
    {
        [Display(Name="Accounting")]
        Accounting,
        [Display(Name="Administration & Secretarial")]
        AdministrationAndSecretarial,
        [Display(Name="Advertising, Media, Arts & Entertainment")]
        AdvertisingMediaArtsAndEntertainment,
        [Display(Name="Agriculture, Nature & Animal")]
        AgricultureNatureAndAnimal,
        [Display(Name="Banking & Finance")]
        BankingAndFinance,
        [Display(Name="Biotech, R&D, Science")]
        BiotechRAndDScience,
        [Display(Name="Construction, Architecture & Interior Design")]
        ConstructionArchitectureAndInteriorDesign,
        [Display(Name="Customer Service & Call Centre")]
        CustomerServiceAndCallCentre,
        [Display(Name="Editorial & Writing")]
        EditorialAndWriting,
        [Display(Name="Education, Childcare & Training")]
        EducationChildcareAndTraining,
        [Display(Name="Engineering")]
        Engineering,
        [Display(Name="Executive & Strategic Management")]
        ExecutiveAndStrategicManagement,
        [Display(Name="Government, Defence & Emergency")]
        GovernmentDefenceAndEmergency,
        [Display(Name="HR & Recruitment")]
        HRAndRecruitment,
        [Display(Name="Health, Medical & Pharmaceutical")]
        HealthMedicalAndPharmaceutical,
        [Display(Name="Hospitality, Travel & Tourism")]
        HospitalityTravelAndTourism,
        [Display(Name="IT")]
        IT,
        [Display(Name="Insurance & Superannuation")]
        InsuranceAndSuperannuation,
        [Display(Name="Legal")]
        Legal,
        [Display(Name="Logistics, Supply & Transport")]
        LogisticsSupplyAndTransport,
        [Display(Name="Manufacturing & Industrial")]
        ManufacturingAndIndustrial,
        [Display(Name="Marketing")]
        Marketing,
        [Display(Name="Mining, Oil & Gas")]
        MiningOilAndGas,
        [Display(Name="Other")]
        Other,
        [Display(Name="Program & Project Management")]
        ProgramAndProjectManagement,
        [Display(Name="Property & Real Estate")]
        PropertyAndRealEstate,
        [Display(Name="QA & Safety")]
        QAAndSafety,
        [Display(Name="Retail")]
        Retail,
        [Display(Name="Sales")]
        Sales,
        [Display(Name="Security")]
        Security,
        [Display(Name="Trades & Services")]
        TradesAndServices,
        [Display(Name="Voluntary, Charity & Social Work")]
        VoluntaryCharityAndSocialWork
    }
}