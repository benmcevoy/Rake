﻿using System.Linq;

using Xunit;

namespace Rake.Tests
{
    public class TutorialComparison
    {
        [Fact]
        public void More_Compex_Comparison_From_Tutorial()
        {
            
            var rake = new Rake(minCharLength: 5, maxWordsLength: 3, minKeywordFrequency: 4);
            var result = rake.Run(text);

            Assert.NotNull(result);

            //expected was
            /*
             * 
             * Keywords: Keywords: [
             * ('household food security', 7.711414565826329), 
             * ('indigenous groups living', 7.4), 
             * ('national forest programmes', 7.249539170506913), 
             * ('wood forest products', 6.844777265745007)
             * 
             * */

            Assert.Equal("household food security", result.Skip(0).First().Key);
            Assert.Equal("indigenous groups living", result.Skip(1).First().Key);
            Assert.Equal("national forest programmes", result.Skip(2).First().Key);
            Assert.Equal("wood forest products", result.Skip(3).First().Key);

            // and scores, but i don't expect the precision to be the same, maybe 2dp?
            Assert.Equal(7.711414565826329, result.Skip(0).First().Value, 2);
            Assert.Equal(7.4, result.Skip(1).First().Value, 1);
            Assert.Equal(7.249539170506913, result.Skip(2).First().Value, 2);
            Assert.Equal(6.844777265745007, result.Skip(3).First().Value, 2);

        }

        const string text = @"<title>Considering nutrition in National Forestry Programmes</title>
<section>1</section>
Nutrition and household food security: their importance for national forest programmes
A. Dependency on forest and trees for household food security and nutrition
A.1. Forests as sources of food
A.2. Forests as sources of fuelwood
A.3. Forests and in kind contributions to the household economy
A.4. Forests and medicinal plants
A.5. Forests as a source of income
A.6. Forests and food production
B. implications of forest management and/or conservation measures on household food security and nutrition
C. developing tools for assessing dependency of local population on forests and trees
Nutrition and household food security: their importance for national forest programmes
A. Dependency on forest and trees for household food security and nutrition
Forests and trees can contribute to household food security and appropriate nutrition through a variety of mechanisms. Local people can use them to meet household needs in terms of food, fuelwood, shelter, income, medicine. They also contribute to sustainable development through environmental protection.
A.1. Forests as sources of food
- In predominantly subsistence economies in remote areas, many forest and tree foods make important contributions to household nutrition. Forest foods combine foods from plant and animal origin. Plant foods are often classified into fruits and seeds, nectars and saps, stems and tubers, leaves and mushrooms. Animal foods can be of invertebrate (insects and insect larvae) or vertebrate (bushmeat or fish) origin. Almost everything that is edible is consumed. Forest foods or ''bush foods'' are often associated with wild or non-cultivated plants and animals. The dichotomy between ""wild"" and ""domesticated"" is however often artificial as the analysis of local farming systems in forested areas world-wide shows a continuum from subsistence foraging to commercial agriculture. The dividing line between foraging and agriculture is therefore a thin one.
- Forest foods provide a wide variety of nutrients: carbohydrates, such as starches, fructose and other soluble sugars, protein, fats and micronutrients(vitamins and minerals). Different parts of the same species are consumed as food by different population groups.This is, for example, the case in various palm varieties: local people consume palm foods as cooked fruits, as hearts of palm, as vegetable oil, as palm wine(the sap is rich in protein, vitamins and iron) or in the form of flour for baking.Their high contents in fats and beta-carotene render them particularly important for the nutritional welfare of the population.Another example is the baobab (Adansonia Digitata): the leaves, either fresh or dried and ground to a powder, are added to the staple of grain crops.The fruit is also eaten.Processing techniques also vary from one population group to another, determining the nutritional content and quality of the food eaten.
- In many parts of the world, hunting still remains an important subsistence activity and bushmeat still provides a critical source of protein for both urban and rural populations.In Amazonia, indigenous groups living near large rivers acquire up to 85% of their dietary protein through fishing. Snails and rats may be eaten several times a week in some villages.
- Although neither forest nor tree foods are typically dietary staples, they do play an important supplementary role in the diet.
Contribution to the energy content of the diet of three populations in Cameroon (Koppert et al., ""Food consumption in three forest populations of the southern coastal area of Cameroon: Yassa, Mvae, Bakola"", in Tropical forests, people and food, UNESCO, 1993)
Contribution to the protein content of the diet of three populations in Cameroon(Koppert et al., ""Food consumption in three forest populations of the southern coastal area of Cameroon: Yassa, Mvae, Bakola"", in Tropical forests, people and food, UNESCO, 1993)
Forest foods contribute to diet diversity and consequently may improve the quantity and quality of food intake.Seasonality is an important constraint for foraging and determines, to a great extent, variations in the diet of indigenous people.Seasonality constraints have therefore generally been built into traditional farming systems.Forest foods also provide a safety net before harvest when food supplies are low, and during famines or natural disasters.In many agricultural communities, people rely on a staple crop, the seasonality of which implies periods of food shortage -usually referred to as ""lean season"" or ""hungry season"" which affect in priority the poorest households.In lean periods, when few cultivated varieties of food are available, storage facilities are empty and/or money is in short supply, hunting and gathering helps alleviate seasonal hunger.This explains while the peak collection of forest fruit does not occur during the main fruiting season, when
fruits are most plentiful, but rather when they are most needed, that is when cultivated food supplies dwindle and the requirements for agricultural labour are limited. Some forest foods are also consumed in times of scarcity as a substitute for staple foods.
Table 1. Seasonal variation in food products available in the village of Kibangu.
Minor season
Major season
Dry
Rainy
Dry
Rainy
(Jan-Feb)
(Mar-May)
(Jun-Aug)
(Sep-Dec)
J
F
M
A
M
J
J
A
S
O
N
D
Harvest period
Dry period
Transition per.
Lean period
Manioc
Manioc
Manioc
Manioc
Maize
Maize
Maize
Mushrooms
Cowpeas
Cowpeas
Dry Cowpeas
Wild leaves
Millet
Millet
Millet
Manioc leaves
Bitter Cucumber
B.Cucumber
B. Cucumber
Fruits
Sweet potatoes
Sweet potatoes
Wild leaves
Yams
Yams
Yams
Palm oil
Freshwater fish
Palm oil
Peanuts
Grasshoppers
Dried Peanuts
Beans
Wild snakes
Fruits
Leaves and wild plants
Wild leaves
Insects
Manioc leaves
Rats
Groundnuts
Game
Palm nuts
Fruits
Fruits
Fresh caterpillars
Bought products
(""Seasonal Variation of Diet and Nutritional Status of Young Children in Villages of Kwango-Kwitiu, Zaire Kukwiikila et al., in Tropical Forests, People and Food, UNESCO, 1993).
- The contribution of forest foods to nutrition also varies both among and within households. Poor and landless people are often more dependent on forest foods than those with moderate incomes: one study reports that poor and landless Thai households depend on forest foods 5-6 clays a week while moderate income people rely on forest foods, on average, 3 days a week.Fruits and seeds are consumed as snacks mainly by children and in some cases by women. Ntomba children in Za�re also collect small fry, caterpillars, grasshoppers, crickets which they share among themselves. Some of these foods are actually considered as child food. In Haiti, children are reported to miss school in periods of food scarcity in order to complement their diet with foraging.In the Andes, berries from wild shrubs are eaten by children and constitute a major source of vitamins in their diet.
- Forest foods can be life saving in times of famine or natural disasters as roots, stems and honey can provide energy. In areas when rainfall is low and erratic, fruits of trees and shrubs play an important role as emergency food. Generally however the collection, processing and preparation of such foods is time consuming and they are therefore being progressively abandoned with increasing commercialization and degradation of forest resources.People tend to rely more and more on markets and food aid in times of emergency.
A.2. Forests as sources of fuelwood
Without fuelwood from forests, food consumption or meal frequency may decrease due to rationed cooking times. In turn, the nutritional well-being of household members may suffer. Fuelwood scarcity may also increase the incidence of illness resulting from improperly prepared food. Finally, as fuelwood becomes scarce, women spend more time collecting it, leaving less time for food production, food preparation, income generation, child care and rest.
A.3. Forests and in kind contributions to the household economy
Forest products, both wood and non-wood forest products, have been traditionally used as construction materials or to make ropes, containers, kitchen utensils, tools, canoes or clothing.Many of these in-kind contributions are crucial. Tens of thousands of tons of baobab leaves are thus harvested every year in West African countries.However production and consumption remain entirely a local affair and only a small proportion actually enters the commercial circuits.Their role is therefore generally underestimated.Development planners and technical staff should however not forget that when forest products are not used or available any more for a given function, they have to be replaced by a substitute that usually must be bought and imported in the area and will compete with food within the limited household budget. Contribution of forest products to directly fulfill basic needs is therefore particularly important for the poorest households.In many areas those will use for
example raffia or palm rather than corrugated iron for roofs.
A.4. Forests and medicinal plants
Wild or domesticated plants constitute the main medicinal source in most traditional societies.They offer treatments for the most common ailments and correct micro-nutrient deficiency. Medicinal plants may also contribute to animal health.
By preventing and treating diseases, medicinal plants contribute to the effective biological utilization of food by the individual and therefore to improving nutritional status.Besides this direct contribution, medicinal plants can be bartered or sold and generate income in kind or cash.
A.5. Forests as a source of income
- The sale of fuelwood, wild foods, medicines and forest raw materials, and employment in forestry activities bring essential cash income to many households and communities.This income can then be used to purchase food and medicines.In barter economies, wood and non-wood products can also be exchanged for food.
- Generating income alone does not automatically ensure improved household food security and/or enhanced nutrition.If the control of income is not in the hands of those caring for family health and nutrition, or if people are not aware of the importance of this issue or insufficiently informed, there may be no improvement in nutritional well-being.People's knowledge, attitudes and practices will influence food selection (for production and purchasing), preparation and distribution amongst household members. In some cases, when nutrition and health are given low priority, increased income has actually proven detrimental to nutritional well-being.
- Commercialization of forest products may also be detrimental to local people's diets if over-exploitation of forest foods leads to a decrease or disappearance of food supplies or traditional food sources. Increased exploitation of forest products can also modify the time allocation of different family members and affect some activities previously related to household food production, processing and preparation, or child care.
Non-Wood Forest Products (NWFPs) in rural economies
African rain forest
In a Forest Resource Management Project jointly funded by the government of Ghana and the Overseas Development Administration, UK, a study was carried out in eight villages in the Ashanti and Western Regions of Ghana(Tropical Moist Forest) to examine the uses and role of NWFPs in rural economies and the impact of forest degradation.Particular attention was given to the trade of bushmeat, chewsticks, plant medicines, food wrapping leaves and cane products.
In the daily urban market in Kumasi - the biggest in Ghana - more than 90% of traders are women. 700 people are involved on full-time basis in trading NWFPs, among which:
100 leaves traders: Marantaceae leaves are traditionally used for wrapping foods (including fishy, highly preferred to plastic bags and paper and are widely used by street food vendors.The monthly demand for leaves exceeds US$ 47000, providing an important contribution to the household economy of both rural people and urban traders.Leaf gathering in early rains in particular helps the poorest households to tide over the hungry season;
100 medicine traders: these are mostly women.Some men are specialized in fetishes or specific goods;
25 full-time basket traders(sell 1000-5000 baskets a month). US$ 6730 worth of cane are traded per month in Kumasi. 11 enterprises employ 70 people full-time in cane-processing.Children take up weaving during school holidays;
50 full-time traders for smoked bush meat, 15 for fresh meat, for an annual value of US$ 209000 or an approximate amount of 160 tons.
In two of the villages studied, NWFPs constitute the main source of income.In Kwapanin, women gather leaves for food wrapping because the local economy collapsed due to bush fires.In Essamang, women are involved in sponge-making and men are full-time cane basket weavers (1 00 weavers out of a population of 720).
The high demand for cane has resulted in a dwindling supply of canes and community resentment against outsiders looking for cane.
A.6. Forests and food production
Forests and trees contribute to a more productive environment which in turn leads to the production of more and better crops:
- trees with deep rooting systems extract otherwise inaccessible nutrients from deep in the soil and bring them to the surface via leaf litter.This leaf cover enriches the surface soils for other plant varieties and helps retain moisture.Nitrogen fixing trees also contribute to soil fertility.
- shade provided by trees lowers surface temperatures of soils which is generally beneficial to soil fertility for crop growth and provides protection for animals.
- trees and shrubs planted and managed as wind breaks help control erosion, thereby improving soil quality and leading to increased agricultural production.
- animal fodder collected from forests and trees often enhances meat and dairy production.
In many areas of the world however, traditional agricultural practices are still based on a shift-and-burn approach, which combined with demographic pressure can lead to the degradation of forest resources.With the increase in population and increasing use of natural resources by better-off farmers with access to a higher level of technology, there is a need for increased agriculture production to cover food needs, which could be obtained through intensification of the production system. Poor households however seldom have access to commercial production.The general understanding of the local population is that agricultural land for food production can essentially be gained through cutting down the forest.
Food insecure households are therefore likely to migrate whenever possible to forested areas in order to grow food, which will contribute to deforestation.Governments also think of forest land as ""vacant"" and, for example, may use it as areas for resettlement.This is likely to remain the case unless economically viable alternatives are made available to poor households.
B.implications of forest management and/or conservation measures on household food security and nutrition
- Little information is available per se in the literature on the implications of forest management and/or conservation measures on household food security and nutrition of the indigenous populations, although relevant elements can be found in many project reports.Foresters working in government projects are often aware of the lack of cooperation or even hostility of the local population.
- From the above it is clear that preventing the local population from exploiting certain or all forest resources may have serious implications on household food security and nutrition, and particularly on that of the poorest households. Privatization of forested land can for example prevent or reduce access of poor households to some forest foods, leading to a less diversified diet, or to the loss of an essential source of income at a given time of the year.
- Development policies and programmes have traditionally privileged cash cropping on non-forested land, leading to the devaluation of forest lands.Poor people seldom have access to the resulting increased income from cash crops and as a result are the most dependent on the forest for their nutrition.
Non-Wood Forest Products (NWFPs) in rural economies
(Forested areas in India)
In India, NWFPs are widely produced and used in
Madhya Pradesh, Maharastra, Orissa, Bihar, West Bengal, Gujarat, Andhra Pradesh and North Eastern States.Tribal groups have been progressively pushed into marginal areas where agricultural yields are lower and more uncertain and they therefore rely to a high degree on NWFPs which provide employment to 5,7 million persons per year. Almost 50% of the state forest revenues and 80% of the net export earning from forest produce derive from NWFPs.
In the West Midnapore District of Southwest Bengal, productive species can be classified into 7 categories: raw material for commercial sale or processing, subsistence foods and drinks, animal fodder, fuel, timber and fibers for tools and construction purposes and medicine. A number of species have multiple uses: sal tree leaves are used to make plates for religious ceremonies - which provides an income-generating occupation during agricultural lean periods -, fruit are eaten, seeds are sold to produce edible oils, twigs and branches are used for fuel, and stems are used as roofing poles. The fruit of the mahua - Bassia latifolia - tree are used for fermenting wine, the flowers for human and livestock consumption and the seeds for oil pressing. Fruit and seeds products are very seasonal with harvesting periods ranging from 2 to 6 weeks.
Underestimating linkages between household food security and nutrition of the local population and management and conservation of forest resources can lead, on the one hand, to increased malnutrition and food insecurity in the area, which can lead to migration of the local population, and on the other, to a lack of cooperation of the population or even social unrest, which can undermine long-term sustainability of the NFP.When designing and coordinating a NFP, it is therefore essential to have a good understanding:
- of how much and how specific population groups in the country depend on forests and trees for household food security and nutrition, and
- of the impact of changes in forest access on vulnerable households.
C.developing tools for assessing dependency of local population on forests and trees
The Community Forestry Unit in FAO with assistance from Food and Nutrition division has therefore focused in the last years:
- in understanding better the dependency of people on forest and trees for household food security and nutrition and the impact of changes in access in forest resources;
- on documenting this information as reference for foresters working in similar environments;
- in developing and testing methodological tools enabling foresters to obtain the necessary information when designing and/or evaluating forest management or conservation programmes and projects.
Within this framework, FAO and the Swedish International Development Agency (SIDA) have undertaken in-depth case studies to determine how dependent people are on forests and trees for good nutrition and food security in different geographical and socio-economic contexts. The general objectives of the studies are to understand how, when and in what way different communities and households are dependent on forest and tree products for food security. The methodology used relies partly on the use of participatory appraisals techniques, as a means to gain a better understanding of people's food systems and related perceptions. The aim of these studies is to provide foresters with an in-depth understanding of the main nutrition and food security concerns of households and of their relation with forest management issues as a basis for planning.
Forest Dependency Studies
In Tanzania, two villages were studied, one close to a proposed forest reserve (Mbambakofi) and the other further from the forest, but with villagers still using forest products(Nanguruwe). The most important food obtained from the forest was the Ming'oko root (Dioscorea sp.). Even in Nanguruwe, where the root is not grown, Ming'oko is very important.According to women in the villages, this root is more important than all other domesticated food crops except cassava. It is available and consumed throughout the near. but it is especially important as a coping strategy during the ""hungry season."" Ming'oko was also a cash crop used by women. Population pressure and the desire to expand cassava farms has led to the deterioration of forests, declining soil fertility and land-shortage. It was also suggested that the availability of forest foods is declining (Missano et al. 1994).
Changing acces
_ As part of the Forests, Trees and People Program me, field studies of the socio-economic aspects of forest dependence in relation to food security were completed in two villages (Bagak and Sungat Bonghang) in West Kalimantan, Indonesia.
_ Using a variety of techniques such as rapid appraisal, semi-structured interviews, mapping and questionnaires the studies explored how socio-cultural, economic, political and environmental changes have affected swidden cultivators' management of forests and trees.
Study results show that villagers in both communities depend on trees.In Bagak, villagers depend on intensively managed tree gardens.Sungai Bongkang villagers, on the other hand, rely on mixed tree gardens and old growth forest.These villagers are directly dependent on forest swiddens for most of the food they consume.
Results also reveal that villagers are dependent on the forest for a significant part of their food and income and are vulnerable to changes in access to the forests. During the past sixty years a variety of changes have reduced the amount of forest land available for collection of forest products and conversion to agriculture.
In both villages, diversity of crop production and income generating opportunities is key in the ability of the villages to ensure food security.This diversity protects against crop failures and shortages due to climatic and political vagaries. Villagers are, however, still vulnerable to government acquisition and privatization of traditionally managed resources.The studies show that the landscape continues to be transformed by logging, plantation development and integration into the world market. Without attention to the affects of these changes, villagers dependent on the forest for their livelihoods may see a growing problem of food insecurity (Peluso, 1993).
In two communes studied in North Vietnam, NacCon and Yen Lap, forest and tree products were found to play an important role in household food security in terms of meal quality, and sustenance during food shortage periods.The dependence on forest and tree products for food security varied by socioeconomic groups.Poor people in both NacCon and Yen Lap depended on forest products for food more than the better off people.The dependency varied by season.
Because of pressure to meet food needs forest land is being destroyed for the production of food and forest products are becoming scarce. This could have a negative effect, if the poor who depend on this resource, do not have access to the cultivated foods (Yen et al. 1994).
<section>2</section>
How to consider nutrition and household food security in the NFP planning process
A.Phase I: Organization of the process
A.1. Identifying stakeholders
A.2. Dissemination and exchange of information
B.Phase II: Strategic planning
B.1. Review of forestry and forest related sectors
B.2. Development of specific studies
B.3. Policy Formulation and Action Planning
C. implementation of actions
C.1. Institutional aspects
C.2. Monitoring and evaluation
How to consider nutrition and household food security in the NFP planning process
This section will follow the phases recommended for the formulation of the National Forest Programmes (NFPs) in the document "" Basic Principles and Operational Guidelines (FAO, Rome 1996)"" ^2 and for each phase will describe the actions to be taken to incorporate household food security and nutrition considerations.
^2 Also consult FAO, 1993 and FAO, 1991b.
A.Phase I: Organization of the process
A.1. Identifying stakeholders
In order to incorporate nutrition considerations into the formulation or revision of NFPs, it is important to identify institutions, community groups and people concerned with household food security and nutrition issues, both at national level and in forested areas.
1. At national level, the preparation of the International Conference of Nutrition (ICN, December 1992) and its follow-up, and in particular the preparation of the National Plans of Action for Nutrition, has contributed to strengthening the coordination between the different institutions.In all countries, a focal point has been identified and in most countries, an Inter-institutional Food and Nutrition Committee has been set up.Ministries of agriculture, health, education and rural development are usually involved in food and nutrition issues and some Non Governmental Organizations (NGOs) may also play an important role in this field.The coordination mechanism set up for the ICN can facilitate identification and contacts with these institutions. NFP staff should therefore contact the FAO (or WHO) Representation in the country to get this information.
2.In forested areas, a variety of institutions and people are involved in / and concerned with development activities at community level which have a direct or indirect impact on household food security and malnutrition. These include government staff working at local level (health staff, agriculture extension staff, teachers), NGOs, people's organizations (e.g. local leaders, women's groups, trade unions, religious leaders...), food processors, food traders(shopkeepers intermediaries)...These institutions / people can be identified locally through district authorities and/ or key informants.
3.Collaboration with different sectors and community groups will ensure a multi-disciplinary and participatory approach to the NFP. They should therefore be involved from the start whenever possible in the formulation or revision of NFPs.
A.2.Dissemination and exchange of information
Meetings should then be organized, both at national and at local level in forested areas, with the people/ institutions concerned, to collect relevant information and discuss a possible cooperation.Initial contacts may need to be made on a one-to - one basis but joint meetings can also be helpful in generating a consensus.This process will both ensure effective collection of relevant data and involve stakeholders in the planning of strategies and activities in the implementation of which they will play a role.It will therefore contribute to improving project design and increasing its sustainability.
B.Phase II: Strategic planning
B.1.Review of forestry and forest related sectors
-As part of an initial assessment of the main problems and opportunities for forest resource conservation and management, it is important to consult the existing information on forest users and nutrition.
- Information on food - related practices of population groups living in forested areas or in their vicinity, including their food habits and perceptions of foods, is essential for understanding of
a the local food and nutrition situation and its evolution and
b people's practices regarding the exploitation of forest resources.
- Much of that information can usually be found in the scientific literature, since the issue is of interest to social sciences researchers or biologists(and in particular anthropologists or ethnobotanists).However the latter are likely to concentrate on specific population groups or on the local fauna and flora rather than on the local food and nutrition situation.Development planners and policy makers may not even be aware of the existence of this material.Moreover, the professional background of the authors and the requirements for scientific publications can render this information difficult to find, understand and use.
- Some information on the productivity, nutritional value and use of locally relevant NWFPs may be available but is often fragmentary.Checklists of wild plant and animal species eaten by rainforest people now exist for many countries and databases on their nutritional value are being set up.If not, relevant data ^ 3 can be found in existing food composition tables in similar ecological areas.Development institutions however usually do not know that such information exists.
^ 3 These data should be used critically since the chemical composition of plants varies according to its age and geographical origin (it varies according to climate, altitude or soil).
-""Hard data"" on the contribution of NWFPs to local diets are often seen as necessary to raise the awareness of policy-makers as to their potential or to warn them against possible negative implications of development programmes on the food and nutrition situation of indigenous groups if the contribution of NWFPs to local consumption patterns is ignored.In fact little information is available on the impact on diets of the reduced consumption of forest foods. Such data are either missing or inadequate since consumption of forest foods is generally under - reported and nutrition studies generally do not address this topic specifically.
-This is also the case for the economic significance of NWFPs.As a rule, no estimates are made of the cash equivalent of their indirect contribution to food security of subsistence households.
- Existing information on the nutritional status of indigenous groups living in or near forested areas, its evolution and its relation with the national average can provide a good indicator of the severity of the problem.
- NFP staff should therefore contact academic institutions(departments of social sciences - anthropology, ethnology, sociology... -, nutrition, forestry and botanic, environment) in the country to ask for relevant information for incorporation in the document presenting the results of the sectoral review.
The following points should be considered:
1.Identification of forested areas;
2. for each forested area, identification of population groups living:
� in forested area
� near forested area
� seasonally passing through
3. for each of these groups:
� size and lifestyle(habitat, farming systems / income generation)
� food consumption habits
� use of forest products(what ? when ? by whom ? what for?)
� nutritional status/ existence of nutritional problems
 B.2.Development of specific studies
- For each forest area identified in the review of the forestry sector, a more in depth study of food security and nutrition should be done in the framework of the in-depth sector analysis.
-The information collected during forestry sector review will need to be complemented at local level through:
� interviews of key informants (see institutions / people identified in section ""Identifying stakeholders"".)
� revision of locally available information
� rapid appraisal (RRA)of the food and nutrition situation of indigenous groups living in and near the forest area identified.
- This study will provide complementary information on household food systems(how does the household acquire and process the food it consumes: what ? when ? where ? who ?) and their evolution, will identify constraints to nutrition and food security, will explore the interface between forestry and nutrition, identify possible lines of action and corresponding indicators.Check-list # 1 provides a list of issues to be explored during the RRA exercise. Table 2 provides a list of RRA techniques selected as particularly relevant to the issues addressed.
Multi-disciplinary teams
In North Vietnam, RRA was found to be an effective methodology for the collection of information related to forestry and food security. The researchers found that a multidisciplinary team composed of forestry sector personnel, nutritionists and social scientists was essential to address the multi-faceted issues involved in dependency on forests and trees for food security. In particular, interviews were helpful in determining community dependency on forest and tree products for food security including the most vulnerable groups, and the forest and tree species used by local people (Yen et al. 1994).
- The participation of the community and of local development institutions in determining forest related problems and activities will ensure an appropriate focus and sustainability of the project.
- Besides, most of the knowledge on local edible plants (harvesting, processing, preparation) is part of indigenous knowledge.In many parts of the world, this knowledge is being lost at an accelerated pace and disappears with changes in lifestyle (decrease in subsistence use of wild species, changing occupational patterns of household members) and disappearance of village elders.Retrieving this knowledge on a systematic basis would provide invaluable information to forestry planners.
- Whenever possible, holding a multi-disciplinary planning workshop gathering the different stakeholders at the local level to review findings, help identify lines of action and allocate responsibilities would be an effective means to generate the required consensus and ensure the involvement of existing institutions in the implementation of follow-up activities. Food and nutrition could be the main topic or one of the issues in such a workshop.
Finally, NFP staff should ensure that the outcome of these action-oriented studies are adequately incorporated in the overall planning process and in particular that relevant aspects are included in the list of options produced during the strategic planning phase.
Table 2
Participatory Methods for Gathering Forestry and Nutrition Information
Method Information Gathered
Seasonal calendar
Cropping patterns, food prices, food availability(cultivated and wild), common illnesses, economic activities
Oral traditions patterns
Food habits, social uses of food, changes in food
Maps
Food production and gathering sites, fuelwood collection sites, food distribution sites, water sources, health facilities, houses
Time charts of representative individuals
Task allocation, use and availability of time, gender issues, role of children
Ranking
Preferences, priority problems
Popular theater. Role playing, Games, Celebrations
Raise community awareness about food security and nutrition issues, promote participation
Checklist # 1
1. Forest and tree resources
_ Who uses and to what end are the forests and trees used? (food production, income generation, fuel wood, etc.)
_ Are there limitations in terms of access to forest and tree resources?
_ Do access restrictions have a more serious effect on food supply or nutrition during particular seasons ?
_ If fuel wood is collected, who collects it and what is the estimated fuel collection and what is the estimated fuel collection time ?
_ Does fuel wood supply limit the number of meals cooked a day or limit the time available to women or men for other activities?
_ What food processing/preservation or income generating activities require fuel wood ?
2. Nutrition and food security
_ Is malnutrition a familiar notion to the community?
_ What does the community perceive as malnutrition? How important is it?
_ How many thin children or adults are there in the community?
_ How do people describe or explain this?
_ What do they do about it?
_ What are the contributing factors to nutrition problems in the area? (geographic area, farming system, poverty, labour, land, policies, infection, food supply, women's time, cultural/religious factors, etc.)
_ Who are the nutritionally vulnerable? (Is it related to gender, age, landholding or ethnic group?)
_ Are there seasonal dimensions to nutrition problems?
_ What do community members say about the nature and importance of wild foods ?
_ What do the residents say about food related problems?
_ Do they identify constraints in availability/ scarcity of specific food items?
_ What is the food storage capacity and what are the storage methods?
3. Income generation
_ Who is employed in forestry or earns money from forest/tree products or processing ?
_ What forestry products are traded?
_ Does it vary by season?
_ What products are used by small scale enterprises for processing?
_ When are the cash need periods?
_ Are some forest products sold to obtain cash for the purchase of basic foods?
_ Are there periodic shortages of these products ?
_ Are there ownership/tenure patterns that regulate the exploitation of these products ?
4. Health/Infection
_ What are the prevailing diseases in the community? Who suffers from them?
_ When do people suffer from them most?
_ What causes them?
_ How do people deal with disease?
_ What support is available? (Traditional healers, Community health worker, Health services) vices)
_ Are there medicines derived from trees and-forests that can alleviate these problems?
5. Living environment
_ Where does the community or household get its water for drinking, food preparation, washing and agricultural uses ?
_ What happens to waste water ?
_ How many rooms do typical households have for how many people ?
_ What are the practices regarding defecation ?
_ What are the hygiene practices in relation to food preparation, consumption and storage ?
B.3.Policy Formulation and Action Planning
On the basis of the information gathered, NFP staff should be able to ensure that food security of households living in and / or near the forested areas considered has been systematically taken into account when finalizing planning of forest development(management and conservation) activities to be included in the Plan of Action, that specific activities have been designed to promote food security and appropriate nutrition of vulnerable households and that effective coordination has been established with local institutions involved in nutrition - related activities.
A Including Household Food Security and Appropriate Nutrition of indigenous groups in NFP objectives
Improving the quality of life(and in particular the satisfaction of basic needs such as food and shelter) of indigenous groups living in or near forested areas should be an explicit objective of all NFPs.A food security and nutrition goal must be included in the National Forest Policy.
B Incorporating Household Food Security concerns into forest development
The main thrust of National Forest Programmes is to make the best use of existing forest resources.These plans will therefore combine a series of activities to promote a more rational exploitation of these resources and to ensure their conservation.
It is important to consider the potential negative effects of these activities on nutrition, as well as the tradeoffs.Some of them could for example:
-reduce food production by affecting traditional farming systems;
-reduce the access to forest products for those most dependent on those resources
- or increase the time women spend involved in a particular activity(e.g.collecting fuel wood).
In view of the information gathered all activities should be systematically screened in terms of their impact on household food security and nutrition of the local population.Whenever possible their design should be revised accordingly.
Considering Household Food Security issues is often in the foresters' and environmentalists' best interest: if both wood and non - wood forest products are seen by the local population both as a source of food and as an important source of local income, they will make sure that such forest resources are managed sustainably.
Forest management
Researchers in Northeast Thailand recommended that forest management must protect the remaining forest and provide for the needs of people who have traditionally depended on the forest for a wide range of products(Saowakontha et al. 1993).They mad e several specific recommendations:
-employ the most vulnerable in reforestation efforts;
    -pay daily wages;
    -provide training and education in how to improve soil quality emphasizing the environmental contribution that forests make
-provide nutrition education and education for school children plant fast growing trees
- listen to the opinion of the headman and community members in project development.
C Designing activities to promote household food security and nutrition
Specific activities to promote household food security and appropriate nutrition of the local population should be systematically incorporated into NFPs.
On the basis of the information gathered in Phase II and in coordination with beneficiaries and local development institutions, NFP staff will:
_ define target groups:
-food insecure households living in or near the forested area(s). (e.g.female - headed, unemployed, landless, land - poor...);
    -households living in or near forest areas which depend permanently or periodically or occasionally on the use of forest resources for food security;
   -communities and households suffering from poor environmental conditions linked to the degradation of natural resources(in particular insufficient or low - quality water supply), resulting in impaired health and malnutrition of vulnerable individuals.
   _ design activities addressing the constraints faced by these target groups.These could include and / or combine:
-improved food production(increase and / or diversification), e.g.agroforestry, home gardens, domestication of forest resources, ...
   - income - generating activities based on a more rational exploitation of wood and non - wood forest products(production but also processing, storage and commercialization) and on the creation of local forest - related industries;
    -improved access to fuel
   - improved living environment (e.g.reforestation, protection of water sources)
-more effective selection of tree species
- ensuring positive benefits for nutritionally vulnerable groups.
Given the key role played by women in most of these issues, the incorporation of household food security and nutrition concerns in NFPs will lead to the development of activities which will both facilitate their tasks and enable them to deal effectively with the constraints they are facing.
D Ensuring local coordination
Malnutrition is the outcome of a combination of intersectorial causes which result in disease, insufficient access to food, and poor nutrition practices.NFPs should include activities to address the causes related to forest use but cannot be expected to address other causes which existing development institutions(government or NGOs) arc better equipped to handle.
The consultation and coordination process initiated from the start between the different stakeholders(see A.1.and following) will have led at local level to a common understanding of which arc the vulnerable households and what constraints they are facing.It is expected that the institutions involved will follow up on the issues relevant to their mandate and / or expertise.In the case that the resources required are available either in the community or in the relevant institution(s), some activities may actually be initiated immediately.
NFPs should actively promote the coordination mechanism required to ensure an integrated approach at household level, for example by promoting inter - institutional meetings at local level to discuss progress of activities and the difficulties encountered.
FAO Forest and Food Security Projects
- Fores et Securite Alimentaire en Afrique Sahelienne"" This project is aimed at developing forestry's contribution to food security in Cape Verde, Mali and Faso.
_ In Cape Verde the main components of this project are the
- strengthen the national forestry service by developing national technical skills;
    -develop, based on a participatory approach, pilot models for management of Prosopis plantations in Santiago and Maio;
    -promote development fruit tree and beekeeping in several different locations.
   _ In Mali, the main objective is to implement a participatory forestry management plan for Kaboila State Protected Forest.
   _ In Burkina Faso, the goals are to implement a participatory forest management plan for 10000 ha of natural village forests and to increase agropastoral production yields.
   A pre - formulation mission in mid 1993 made several recommendations concerning participatory methodologies, natural resource management and income generating activities.They emphasized strengthening project staff skills in the participatory approach and collaborating closely with national institutions at all levels.Project outputs due in the near future are a thematic mapping of communities and training tools for specific subjects.
-As an early part of FAO's project ""Forestry and Food Security"" in the Mid and Near East Region, project staff have listed potential activities focusing on:
   - improving and managing forest pasture
   - managing forests for fuelwood production
   -improving communal rangeland
   - reducing afforestation costs
   - introducing alternative sources of energy
   - enhancing agroforestry
   - setting up experimental design plots.
   C.implementation of actions
   C.1.Institutional aspects
   - In order to ensure that Nutrition concerns are adequately addressed in the formulation of the NFP, one person in the National Coordinating Unit should be responsible for food and nutrition issues.This person should work in close collaboration with the person / institution coordinating the follow - up of the International Conference for Nutrition in the country and in particular the preparation and implementation of the National Plan of Action for Nutrition.
      - Local training on food security and nutrition and / or visits by relevant national or international experts(e.g.nutritionists) to the area should be encouraged as this would provide further opportunities for exchange of information and dialogue between food security and nutrition partners and would contribute to build up the capacity of field staff.
     C.2.Monitoring and evaluation
     At community level
     - The participatory monitoring and evaluation(M & E) of the impact of NFP activities on nutrition and food security is essential to ensure continuous feedback and adjustments based on experience.If the community has been effectively involved(see phase III) in problem analysis and selection of activities, the corresponding indicators will likely be acceptable to both NFP staff and beneficiaries.The involvement from the start of other institutions active at local level will also ensure that they are compatible with existing data - collection and monitoring systems at community and local level.
     - NFP activities are likely to affect the food and nutrition situation of households in a variety of ways, which will depend on local ecological and socio - cultural factors.The following list(Checklist #2) is therefore indicative and will need to be adapted and completed on the basis of the analysis carried in phases II and III.
At local level
     - Information collected and analysed at community level through this participatory approach must be collated and discussed at local level by the institutions identified in section A. 1.
     - The inter - institutional coordination process required to improve the local food and nutrition situation should be monitored and supported by the NFP.
     Setting up a Food and Nutrition Surveillance System
     An important element of the policies selected in Phase IV should be the development of an effective food and nutrition surveillance system for monitoring purposes. A local system should be designed on the basis of the information gathered in phases I to III, of the resources of existing institutions and according to the activities considered to improve the food and nutrition situation of households living in and near forested areas.It should then be integrated into existing monitoring systems at community and local level.Finally it should be integrated into regional and / or national food and nutrition surveillance systems and / or other related monitoring system.
     Checklist # 2
1.Food practices
     _ Range of foods used over the seasons, snack food consumption, gathered forest foods
     _ Duration of crop availability reliability of crop production year to year, number of months of staple food self - sufficiency, duration of hunger periods.er periods.
     _ Perceptions of foods(e.g.foods perceived as luxuries or delicacies)
     _ Frequency of meals and snack foods
     _ Amount of stored foods, length of food storage
     _ Number of meals reheated, dishes saved but not reheated before eating
     _ Child feeding practices including medicines and ""health"" foods fed to children when ill, extent of consumption of snack foods, meal frequency, weaning foods
     _ Coping mechanisms: emergency measures during hunger periods, foods consumed only in famine situations
     _ Availability of alternative food sources, especially forest foods
     _ Periods of market availability and prices of foods in hunger periods
     2.Income
     _ Cash requirements - regular, occasional(tax payments, school fees,
     _ How income spent(on more food ? other basic needs ? ""luxuries"" ?) and invested(e.g. in land, livestock, new tools)
     _ Who within the household earns, spends and controls money ?
     _ Change in purchasing power and debts
     _ Food purchases during hunger periods
     _ Livestock sold to tide through emergency period
     3.Environmental health
     _ Housing
     _ Water quality and quantity
     _ Incidence of environmentally induced disease
     4.Equity
     _ Changes in the division of labour and time use by gender
     _ Changes in distribution of production resources
     _ Changes in income distribution
     _ Changes in distribution of knowledge and skills nd skills
     5.Community participation
     _ Percentage of households involved in at least one activity
     _ Changing size of group membership during the project ing the project
     _ Frequency of attendance at meetings
     _ Involvement of marginalized households lds
     _ Number of person / days of labour involved in project activity
     _ Number, percentage and gender of persons assuming leadership roles
     6.Interactions of the community with external services
     _ Number and types of institutions with which the community has established regular links
     _ Participation of community in external decisions affecting it directly
     _ Number of people trained by external institutions
     < section > 3 </ section >
     Where to find help ?
     1.List of suggested complementary readings
     2.Institutions
     Where to find help ?
     1.List of suggested complementary readings
     Falconer, J. (1990).The Major Significance of Minor Forest Products: The Local Use and Value of Forests in the Humid Forest Zone.Community Forestry Note 6.Rome: FAO.
     Falconer, J. & Arnold, J.E.M. (1989).Household Food Security and Forestry.An Analysis of Socio - Economic Issues.Community Forestry Note 1.Rome: FAO.
     FAO. (1989a).Forestry and Nutrition: A Reference Manual.Rome: FAO.
     FAO. (1989b).Forestry and Food Security Forestry Paper 90.Rome: FAO.
     FAO. (1990).Food for the Future. Rome: FAO.
    FAO. (1990 / 1).Unasylva, 160(vol. 41).Rome: FAO.
    FAO. (1991a).Forests, Trees, and Foods.Rome: FAO.
    FAO. (1991b).Incorporating Nutrition Concerns into Forestry Activities.Community Forestry Manual 3.Rome: FAO.
    FAO. (1991).Socio - Economic Attributes of Trees and Tree - planting Practices.Community Forestry Note 9.Rome: FAO
    FAO. (1993).Guidelines for Participatory Nutrition Projects.Community Forestry Field Manual 3.Rome: FAO.
   FAO. (1995).Selecting tree species on the basis of community needs - Community Forestry Field Manual 5.
   Hladik, C.M., Hladik, A., Linares, O.F., Pagezy, H., Semple, A. & Hadley, M. (eds.)(1993).Tropical Forests, People and Food.Biocultural Interactions and Applications to Development.UNESCO, Paris and The Parthenon Publishing Group, New York.
   International Conference on Nutrition - World Declaration and Plan of Action for NutritionRome, December 1992
   Peluso, N.L. (1993).The impact of social and environmental change on forest management.A case study from West Kalimantan, Indonesia.Rome: Community Forestry Case Study Series 8.
   Scoones, I., Melnyk, M & Pretty, J.N. (1992).The Hidden Harvest: Wild Foods and Agricultural Systems.A Literature Review and Annotated Bibliography London: International Institute for Environment and Development.
 2.Institutions
 The Coordinating Unit will need to make an inventory of governmental and non - governmental institutions(including universities) likely to provide information and support to the incorporation of nutritional concerns into NFP formulation and to the implementation of its recommendations.This will vary from one country to the other and the following list can only provide indications.
 Government Institutions:
-Ministry / Department of Agriculture
 - Ministry / Department of Forestry
 - Ministry / Department of Rural Development
 - Ministry of Health
 - Ministry of Education
 Local NGOs
 - Universities / research centres
 - NGOs active in rural development(including religious organizations)
 - NGOs providing health services
 - Natural Resource Management NGOs
 United Nations Agencies
 - FAO Community Forestry Unit
 Food Policy and Nutrition Division
 - UNDP Sustainable Development Network
 304 E 45th Street
 New York, NY 10017 USA
 - UNESCO Trees for Life Collaborative Programme
 1, rue Miollis
 75015 Paris, France
 - UNICEF Environment Section
 UNICEF House
 3 UN Plaza New York, NY 10017 USA
 International Governmental and Nongovernmental Organizations
 - Institut Fran�ais de Recherche Scientifique pour le D�velopment en Cooperation(ORSTOM)
 213, rue la Fayette
 75480 Paris Cedex 10 France
 ORSTOM assists developing countries through research in nutrition and the social sciences among other things.
 - International Centre for Research in Agroforestry(ICRAF)
 ICRAF House, Limuru Road
 Gigiri
 PO Box 30677
 Nairobi, Kenya
 Through research and training ICRAF aims to increase the social, economic and nutritional status of peoples in developing countries.
 - International Food Policy Research Institute(IFPRI)
 Food Consumption and Nutrition Division
 1200 17th Street, NW
 Washington, DC 20009 USA
 IFPRI's activities include research on the effect of deforestation on nutritional status of children.
 - International Institute for Environment and Development(IIED)
 The Sustainable Agriculture Programme
 3 Endsleigh Street
 London WClH ODD UK
 This program emphasizes the refinement and application of participatory appraisal methods in the support of environmentally aware agriculture.
 - International Rural Development Centre(IRDC)
 Swedish University of Agricultural Sciences
 Box 7005
 S - 750 07 Uppsala, Sweden
 IRDC publishes an FTP information letter rural development studies as well as working document';
 - International Science and Technology Institute
 Food Security and Nutrition Monitoring Project(IMPACT)
 1129 20th Street, NW Suite 800
 Washington, DC 20036 - 3434 USA
 The IMPACT project provides funding to activities related to local use of forest resources such as the project on forest use of remote forest groups in Ecuador
 - International Social Science Council(ISSC)
 1, rue Miollis
 75015 Paris, France
 ISSC promotes research in social science with application to major problems in the world.ISSC has a standing committee on Human Dimension of Global Environmental Change.
 - Overseas Development Institute(ODI)
 Regent's College
 Inner Circle
 Regent's Park
 London NW1
 4NS England
 ODI researchers different issues in agricultural development.
 - World Resources Institute(WRI)
 1709 New York Avenue, NW
 Washington, DC 20006 USA
 An aim of WRI is to help societies meet human needs without destroying natural resources and environmental integrity.One policy research project, in biological resources and institution, includes a focus on forest policy and strategies for sustainable management.
< section > e </ section >
Introduction
Introduction
- Household food insecurity ^ 1 and malnutrition are closely linked to deforestation:
^ 1 Food security is the access by all people at all times to the food needed for a healthy life
 On the one hand, the decrease and degradation of existing natural resources, due to unsustainable management, affect the way in which local people obtain and prepare their food and lead to unhealthy environments;
    On the other hand (and of more concern to foresters and environmentalists), the exploitation of natural resources(e.g.clearing more land from forested areas, selling charcoal) is often the only approach poor households have or know to increase food production and generate income to feed their families.
  - Furthermore, forestry projects almost always change access to land and forest products.It is therefore essential to consider the role of these products in rural livelihoods to ensure that such projects do not further disadvantage the poor but improve the overall nutritional well-being.
 - Therefore, in order to ensure sustainable management of forest resources, it is essential to understand how local food systems (including coping mechanisms) relate to forest resources and to provide, when necessary, viable alternatives to indigenous groups.
-The consideration of household food security and nutrition concerns in National Forest Programmes(NFP's) is consistent with the recent evolution of Forestry development which emphasises multi-disciplinary approaches and the involvement of forest-dependent people in the preparation and implementation of National Forestry Programmes. The aim is to curb forest loss by the promotion of sustainable management of forest resources while meeting local and national needs. Since food is probably the most important basic need and since the diet of households and the nutritional status of their members depend on a wide combination of factors, nutrition and household food security provide an effective entry point for multidisciplinary activities within NFPs.
- The incorporation of these concerns into NFPs is also in line with the World Declaration and Plan of Action for Nutrition adopted by 159 countries at the FAD / WHO International Conference on Nutrition(ICN) in December 1992.As stated in several ICN documents, understanding how households perceive and seek food security is a key to understanding production patterns including the use of forest resources.Since nutritional status is influenced by ecological, social, cultural and economic factors, understanding how these factors relate to forestry will help to identify the links between NFPs and nutrition.Moreover, this type of analysis will ensure recognition of relevant institutions.
- Ensuring effective local participation is essential for identifying and incorporating household food security and nutrition concerns into the NFP.Given women's key role at all stages of the food chain, their participation is particularly important.
- It is a practical guide for National Forest Programmes Coordinators, their teams and all stakeholders involved.The note will be useful during all phases of NFPs.It will be particularly helpful during the strategic planning, for the preparation of specific studies to analyze the forestry and forest related sectors and for the policy making and planning.The note should also provide a means to link NFPs with National Plans of Action for Nutrition developed after the ICN.
- The briefing note is divided into four sections.
1 - Introduction
2 - Importance of nutrition and household food security in NFPs
3 - How to consider nutrition and household food security in NFPs
4 - Sources for more information.
These sources include both relevant literature and institutions involved in research and funding of related projects.Case examples of how forestry projects have focused on nutrition and household food security are included throughout the text.";
    }
}
